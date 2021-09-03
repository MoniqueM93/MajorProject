using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S12Triggers : MonoBehaviour
{
    public GameObject friendA;
    public GameObject friendAPrompt;
    public GameObject friendATalk;
    public DialogueTrigger friendATalkText;

    public GameObject friendB;
    public GameObject friendBPrompt;
    public GameObject friendBTalk;
    public DialogueTrigger friendBTalkText;

    public GameObject friendC;
    public GameObject friendCPrompt;
    public GameObject friendCTalk;
    public DialogueTrigger friendCTalkText;

    public GameObject openingTalk;
    public DialogueTrigger openingTalkText;
    public bool openingTextDone = false;

    public GameObject leaveArea;
    public GameObject leavePrompt;
    public bool readyToLeave = false;

    IEnumerator StartTalkDelay()
    {
        yield return new WaitForSeconds(1);
        openingTalk.SetActive(true);
        openingTalkText.TriggerDialogue();
        openingTextDone = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == openingTalk && openingTextDone == false)
        {
            StartCoroutine("StartTalkDelay");
        }

        if (collision.gameObject == friendA)
        {
            friendAPrompt.SetActive(true);
        }

        if (collision.gameObject == friendB)
        {
            friendBPrompt.SetActive(true);
        }

        if (collision.gameObject == friendC)
        {
            friendCPrompt.SetActive(true);
        }

        if(collision.gameObject == leaveArea)
        {
            leavePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendA)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == friendB)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == friendC)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendCTalk.SetActive(true);
                friendCTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == leaveArea && readyToLeave == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("Let's go home");
                readyToLeave = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == friendA)
        {
            friendAPrompt.SetActive(false);
        }

        if (collision.gameObject == friendB)
        {
            friendBPrompt.SetActive(false);
        }

        if (collision.gameObject == friendC)
        {
            friendCPrompt.SetActive(false);
        }

        if (collision.gameObject == leaveArea)
        {
            leavePrompt.SetActive(false);
        }
    }
}
