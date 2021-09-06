using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S14Triggers : MonoBehaviour
{
    public GameObject friendAChar;
    public GameObject friendATalk;
    public DialogueTrigger friendATalkText;
    public GameObject friendTalkPrompt;

    public GameObject catChar;

    public GameObject dogChar;

    public GameObject famChar;
    public DialogueTrigger famTalkText;
    public GameObject famTalk;
    public GameObject famTalkPrompt;

    public GameObject friendBlocks;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == friendAChar)
        {
            friendTalkPrompt.SetActive(true);
        }

        if (collision.gameObject == famChar)
        {
            famTalkPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendAChar)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                friendBlocks.SetActive(false);
            }
        }

        if(collision.gameObject == famChar)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                famTalk.SetActive(true);
                famTalkText.TriggerDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == friendAChar)
        {
            friendTalkPrompt.SetActive(false);
        }

        if (collision.gameObject == famChar)
        {
            famTalkPrompt.SetActive(false);
        }
    }
}
