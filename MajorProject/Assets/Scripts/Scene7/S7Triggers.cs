using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S7Triggers : MonoBehaviour
{
    //to talk to the chick
    public GameObject chickTrigger;

    //if player goes to bird first
    public GameObject firstChickTalk;
    public DialogueTrigger firstChickTalkText;

    //speak to chick prompt
    public GameObject chickTalkPrompt;

    //check have you spoken to Bessie
    public bool spokeToBessie = false;

    //speak to Bessie
    public GameObject bessiePrompt;
    public GameObject bessieTrigger;
    public GameObject bessieTalk;
    public DialogueTrigger bessieTalkText;

    //if the player goes to bird after speaking to Bessie
    public GameObject postChickTalk;
    public DialogueTrigger postChickTalkText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == chickTrigger)
        {
            chickTalkPrompt.SetActive(true);
        }

        if(collision.gameObject == bessieTrigger)
        {
            bessiePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == chickTrigger && spokeToBessie == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                firstChickTalk.SetActive(true);
                firstChickTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == bessieTrigger)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                bessieTalk.SetActive(true);
                bessieTalkText.TriggerDialogue();
                spokeToBessie = true;
            }

        }

        if (collision.gameObject == chickTrigger && spokeToBessie == true)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                postChickTalk.SetActive(true);
                postChickTalkText.TriggerDialogue();
                print("swap incoming");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == chickTrigger)
        {
            chickTalkPrompt.SetActive(false);
        }

        if (collision.gameObject == bessieTrigger)
        {
            bessiePrompt.SetActive(false);
        }
    }
}
