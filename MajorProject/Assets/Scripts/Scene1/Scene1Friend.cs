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
    public bool S1AllTalkDone = false;

    public bool openingTalkDone = false;

    //audio
    public AudioSource seagullSounds;

    public Transform friendTurnAnim;
    private float postTalkAnimator;

    private void Start()
    {
        postTalkAnimator = friendTurnAnim.localScale.x;
    }

    private void FixedUpdate()
    {
        if (cameraScript.hasFinishedMove == true && openingTalkDone == false)
        {
            seagullSounds.Play();
            openingTalk.SetActive(true);
            openingSpeakText.TriggerDialogue();
        }

        if (openingTalkDone == true)
        {
            openingTalk.SetActive(false);

            friendTurnAnim.localScale = new Vector3(-postTalkAnimator, friendTurnAnim.localScale.y, friendTurnAnim.localScale.z);
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
        if (hasTheFood == false && Input.GetKey(KeyCode.W))
        {
            stealUnsuccess.SetActive(true);
            stolenUnsuccessText.TriggerDialogue();
            speakPrompt.SetActive(false);
        }
        else if (hasTheFood ==  true && Input.GetKey(KeyCode.W))
        {
            stealSuccess.SetActive(true);
            stolenSuccessText.TriggerDialogue();
            S1AllTalkDone = true;
            speakPrompt.SetActive(false);
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
