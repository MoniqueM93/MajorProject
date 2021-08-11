using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S5Triggers : MonoBehaviour
{
    public OpeningCameraS5 S5CamRef;

    public GameObject eadieTrigger;

    public GameObject eadieCallOver;
    public DialogueTrigger eadieCallOverText;

    public GameObject EadieDialogue;
    public DialogueTrigger EadieDialogueText;
    public GameObject EadieTalkPrompt;

    public GameObject cageBlock;

    public GameObject sceneDoor;

    public GameObject fishBoneCollect;

    public bool playOpeningOnce = false;

    private void FixedUpdate()
    {
        if (S5CamRef.hasFinishedMove == true && playOpeningOnce == false)
        {
            playOpeningOnce = true;
            eadieCallOver.SetActive(true);
            eadieCallOverText.TriggerDialogue();
        }

        if (S5CamRef.hasFinishedMove == true && playOpeningOnce == true)
        {
            eadieCallOver.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == eadieTrigger)
        {
            EadieTalkPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == eadieTrigger)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                EadieDialogue.SetActive(true);
                EadieDialogueText.TriggerDialogue();
                EadieTalkPrompt.SetActive(false);
                cageBlock.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EadieTalkPrompt.SetActive(false);
    }
}
