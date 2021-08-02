using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Friend : MonoBehaviour
{
    public GameObject speakPrompt;
    public GameObject openingTalk;
    public GameObject stealSuccess;
    public GameObject stealUnsuccess;

    public DialogueTrigger openingSpeakText;
    public DialogueTrigger stolenSuccessText;
    public DialogueTrigger stolenUnsuccessText;

    public Scene1PickUp stealDoneRef;
    public OpeningCamera cameraScript;

    public bool hasTheFood = false;

    public bool openingTalkDone = false;

    private void FixedUpdate()
    {
        if (cameraScript.hasFinishedMove == true && openingTalkDone == false)
        {
            openingTalk.SetActive(true);
            openingSpeakText.TriggerDialogue();
        }

        if (openingTalkDone == true)
        {
            openingTalk.SetActive(false);
        }

        if (stealDoneRef.beenStolen == true)
        {
            hasTheFood = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            speakPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hasTheFood == false && Input.GetKey(KeyCode.UpArrow))
        {
            stealUnsuccess.SetActive(true);
            stolenUnsuccessText.TriggerDialogue();
        }
        else if (hasTheFood ==  true && Input.GetKey(KeyCode.UpArrow))
        {
            stealSuccess.SetActive(true);
            stolenSuccessText.TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            speakPrompt.SetActive(false);
        }
    }
}
