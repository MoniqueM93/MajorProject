using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S8Triggers : MonoBehaviour
{
    //Classes for friend A
    public GameObject friendA;
    public GameObject friendAFirst;
    public DialogueTrigger friendAFirstText;
    public GameObject friendAPrompt;
    public bool isFirstTalkDone = false;

    public GameObject friendASecond;
    public DialogueTrigger friendASecondText;

    //Claases for friend B
    public GameObject friendB;
    public GameObject friendBTalk;
    public DialogueTrigger friendBTalkText;
    public GameObject friendBPrompt;
    public bool isSecondTalkDone = false;

    //Classes for Pet Door
    public GameObject doorTrigger;
    public GameObject doorPrompt;

    public bool allTalkDone = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (allTalkDone == true)
        {
            doorTrigger.SetActive(true);
            friendA.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == friendA)
        {
            friendAPrompt.SetActive(true);
        }

        if (collision.gameObject == friendB && isFirstTalkDone == true)
        {
            friendBPrompt.SetActive(true);
        }

        if (collision.gameObject == doorTrigger)
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == friendA && isFirstTalkDone == false && isSecondTalkDone == false)
        {
            if(Input.GetKey(KeyCode.W))
            {
                friendAFirst.SetActive(true);
                friendAFirstText.TriggerDialogue();
                isFirstTalkDone = true;
                friendB.GetComponent<BoxCollider2D>().enabled = true;
                friendAPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == friendB)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
                isSecondTalkDone = true;
                friendBPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == friendA && isFirstTalkDone == true && isSecondTalkDone == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendASecond.SetActive(true);
                friendASecondText.TriggerDialogue();
                allTalkDone = true;
                friendAPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == doorTrigger)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene9");
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

        if (collision.gameObject == doorTrigger)
        {
            doorPrompt.SetActive(false);
        }
    }
}
