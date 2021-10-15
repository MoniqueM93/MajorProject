using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S17Triggers : MonoBehaviour
{
    public GameObject friendChar;
    public GameObject friendTalk;
    public DialogueTrigger friendTalkText;
    public GameObject friendPrompt;

    public GameObject babyChick;
    public GameObject chickTrigger;
    public GameObject chickTalk;
    public DialogueTrigger chickTalkText;
    public GameObject chickPrompt;

    public GameObject closingDialogue;
    public DialogueTrigger closingDialogueText;

    public GameObject leaveArea;
    public GameObject leavePrompt;

    public bool hasSpokeToFriend = false;
    public bool hasSpokeToChick = false;

    public bool closingDialogueSpoken = false;

    public bool gameOver = false;
    public bool creditsInbound = false;

    public GameObject finalTutorial;
    public GameObject rightBlock;
    public GameObject endingTrigger;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(hasSpokeToFriend == true)
        {
            friendPrompt.SetActive(false);
        }

        if (hasSpokeToChick == true)
        {
            chickTrigger.SetActive(false);
            chickPrompt.SetActive(false);
        }
    }

    IEnumerator ForClosingDialogue()
    {
        yield return new WaitForSeconds(1);
        gameOver = true;
        closingDialogue.SetActive(true);
        closingDialogueText.TriggerDialogue();
        finalTutorial.SetActive(true);
        rightBlock.SetActive(false);
    }

    IEnumerator gameClose()
    {
        creditsInbound = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("endingcredits");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == friendChar && hasSpokeToFriend == false)
        {
            friendPrompt.SetActive(true);
        }

        if(collision.gameObject == chickTrigger)
        {
            chickPrompt.SetActive(true);
        }

        if(collision.gameObject == leaveArea && hasSpokeToChick == true)
        {
            leavePrompt.SetActive(true);
        }

        if (collision.gameObject == endingTrigger)
        {
            finalTutorial.SetActive(false);
            StartCoroutine("gameClose");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendChar && hasSpokeToFriend == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                hasSpokeToFriend = true;
                friendTalk.SetActive(true);
                friendTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == chickTrigger)
        {
            if (Input.GetKey(KeyCode.W))
            {
                chickTalk.SetActive(true);
                chickTalkText.TriggerDialogue();
                hasSpokeToChick = true;
                babyChick.GetComponent<FollowCode>().enabled = true;
                babyChick.GetComponent<FollowMovements>().enabled = true;
            }
        }

        if(collision.gameObject == leaveArea && hasSpokeToChick == true && gameOver == false)
        {
            if (Input.GetKey(KeyCode.W) && closingDialogueSpoken == false)
            {
                leavePrompt.SetActive(false);
                closingDialogueSpoken = true;
                StartCoroutine("ForClosingDialogue");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == friendChar && hasSpokeToFriend == false)
        {
            friendPrompt.SetActive(false);
        }

        if (collision.gameObject == chickTrigger)
        {
            chickPrompt.SetActive(false);
        }

        if (collision.gameObject == leaveArea && hasSpokeToChick == true)
        {
            leavePrompt.SetActive(false);
        }
    }
}
