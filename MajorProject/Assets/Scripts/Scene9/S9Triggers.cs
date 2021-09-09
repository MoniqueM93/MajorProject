using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S9Triggers : MonoBehaviour
{
    //talking options
    public GameObject standbyTalk;
    public DialogueTrigger standbyTalkText;

    public GameObject collectTalk;
    public DialogueTrigger collectTalkText;

    // for the triggers
    public GameObject standbyTrigger;
    public GameObject standbyBlock;
    public GameObject collectTrigger;

    public GameObject foodCollect;
    public GameObject foodPrompt;

    public bool foodBeenTaken = false;
    public bool chickIsStill = false;

    public GameObject chickRef;
    public GameObject chickAnimateRef;

    //for the doors
    public GameObject doorTrigger;
    public GameObject leavePrompt;

    public bool letsLeave = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == standbyTrigger)
        {
            standbyTalk.SetActive(true);
            standbyTalkText.TriggerDialogue();
            standbyTrigger.SetActive(false);
            standbyBlock.SetActive(false);
            chickRef.GetComponent<FollowCode>().enabled = false;
            chickRef.GetComponent<FollowMovements>().enabled = false;
            chickAnimateRef.GetComponent<Animator>().enabled = false;
        }

        if (collision.gameObject == foodCollect)
        {
            foodPrompt.SetActive(true);
        }

        if (collision.gameObject == collectTrigger && foodBeenTaken == true)
        {
            collectTalk.SetActive(true);
            collectTalkText.TriggerDialogue();
            chickRef.GetComponent<FollowCode>().enabled = true;
            chickRef.GetComponent<FollowMovements>().enabled = true;
            collectTrigger.SetActive(false);
            doorTrigger.SetActive(true);
            chickAnimateRef.GetComponent<Animator>().enabled = true;
        }

        if (collision.gameObject == doorTrigger)
        {
            leavePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == foodCollect)
        {
            if (Input.GetKey(KeyCode.W))
            {
                foodCollect.SetActive(false);
                foodBeenTaken = true;
            }
        }

        if (collision.gameObject == doorTrigger && letsLeave == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                print("Let's goooooo");
                letsLeave = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject == foodCollect)
        {
            foodPrompt.SetActive(false);
        }

        if (collision.gameObject == doorTrigger)
        {
            leavePrompt.SetActive(false);
        }
    }
}
