using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S15Triggers : MonoBehaviour
{
    public GameObject selfTalk;
    public DialogueTrigger selfTalkText;

    public bool selfTalkDone = false;

    public GameObject bessieChar;
    public GameObject bessieTalk;
    public DialogueTrigger bessieTalkText;
    public GameObject bessieTalkPrompt;

    public GameObject nestArea;
    public GameObject nestAreaTalk;
    public DialogueTrigger nestAreaTalkText;
    public GameObject nestAreaPrompt;

    public GameObject leaveArea;
    public GameObject leaveAreaPrompt;

    private void Start()
    {
        if(selfTalkDone == false)
        {
            StartCoroutine("SelfTalkStart");
        }
    }

    IEnumerator SelfTalkStart()
    {
        yield return new WaitForSeconds(1);
        selfTalk.SetActive(true);
        selfTalkText.TriggerDialogue();
        selfTalkDone = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == bessieChar)
        {
            bessieTalkPrompt.SetActive(true);
        }

        if (collision.gameObject == nestArea)
        {
            nestAreaPrompt.SetActive(true);
        }

        if (collision.gameObject == leaveArea)
        {
            leaveAreaPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == bessieChar)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                bessieTalk.SetActive(true);
                bessieTalkText.TriggerDialogue();
                leaveArea.SetActive(true);
            }
        }

        if(collision.gameObject == nestArea)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                nestAreaTalk.SetActive(true);
                nestAreaTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == leaveArea)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("Scene will now change");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == bessieChar)
        {
            bessieTalkPrompt.SetActive(false);
        }

        if (collision.gameObject == nestArea)
        {
            nestAreaPrompt.SetActive(false);
        }

        if (collision.gameObject == leaveArea)
        {
            leaveAreaPrompt.SetActive(false);
        }
    }
}
