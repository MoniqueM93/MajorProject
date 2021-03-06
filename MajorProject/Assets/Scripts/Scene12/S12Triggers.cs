using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Start()
    {
        Time.timeScale = 1;
    }
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
            if (Input.GetKey(KeyCode.W))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                friendAPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == friendB)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
                friendBPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == friendC)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendCTalk.SetActive(true);
                friendCTalkText.TriggerDialogue();
                friendCPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == leaveArea && readyToLeave == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene13");
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
