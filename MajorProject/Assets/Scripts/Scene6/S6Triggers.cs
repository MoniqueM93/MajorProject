using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S6Triggers : MonoBehaviour
{
    public GameObject friendATextPrompt;
    public GameObject friendATalk;
    public DialogueTrigger friendATalkText;

    public GameObject friendBTextPrompt;
    public GameObject friendBTalk;
    public DialogueTrigger friendBTalkText;

    public GameObject leavePrompt;
    public GameObject leaveTrigger;

    public bool readyToSwitch = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == friendATalk)
        {
            friendATextPrompt.SetActive(true);
        }
        
        if (collision.gameObject == friendBTalk)
        {
            friendBTextPrompt.SetActive(true);
        }

        if (collision.gameObject == leaveTrigger)
        {
            leavePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendATalk)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
            }
        }        
        
        if (collision.gameObject == friendBTalk)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == leaveTrigger)
        {
            if (Input.GetKey(KeyCode.UpArrow) && readyToSwitch == false)
            {
                print("GO THE NEXT LEVEL!");
                readyToSwitch = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == friendATalk)
        {
            friendATextPrompt.SetActive(false);
        }

        if (collision.gameObject == friendBTalk)
        {
            friendBTextPrompt.SetActive(false);
        }

        if (collision.gameObject == leaveTrigger)
        {
            leavePrompt.SetActive(false);
        }
    }
}
