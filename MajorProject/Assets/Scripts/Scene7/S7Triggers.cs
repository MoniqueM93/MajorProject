using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool hasTheChick = false;

    //talk to bessie when you have the chick
    public GameObject toBessieWithChick;
    public DialogueTrigger toBessieWithChickText;
    public bool readyToGoWithBird = false;

    //when it is time to leave the map
    public GameObject leavePrompt;
    public GameObject leaveTrigger;

    public GameObject babyChick;

    public AudioSource bessieSounds;

    //Guides
    public GameObject guideTrigger;
    public GameObject playerGuide;

    private void Start()
    {
        Time.timeScale = 1;
    }
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

        if (collision.gameObject == leaveTrigger && readyToGoWithBird == true)
        {
            leavePrompt.SetActive(true);
        }

        if (collision.gameObject == guideTrigger && readyToGoWithBird == true)
        {
            playerGuide.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == chickTrigger && spokeToBessie == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                firstChickTalk.SetActive(true);
                firstChickTalkText.TriggerDialogue();
                chickTalkPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == bessieTrigger && hasTheChick == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                bessieSounds.Play();
                bessieTalk.SetActive(true);
                bessieTalkText.TriggerDialogue();
                spokeToBessie = true;
                bessiePrompt.SetActive(false);
            }

        }

        if (collision.gameObject == chickTrigger && spokeToBessie == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                postChickTalk.SetActive(true);
                postChickTalkText.TriggerDialogue();
                hasTheChick = true;
                chickTalkPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == bessieTrigger && hasTheChick == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                bessieSounds.Play();
                toBessieWithChick.SetActive(true);
                toBessieWithChickText.TriggerDialogue();
                leaveTrigger.SetActive(true);
                readyToGoWithBird = true;
                bessiePrompt.SetActive(false);
            }
        }

        if (collision.gameObject == leaveTrigger && readyToGoWithBird == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene8");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == chickTrigger && hasTheChick == false)
        {
            chickTalkPrompt.SetActive(false);
        }

        if (collision.gameObject == bessieTrigger)
        {
            bessieSounds.Stop();
            bessiePrompt.SetActive(false);
        }

        if (collision.gameObject == chickTrigger && hasTheChick == true)
        {
            babyChick.GetComponent<FollowCode>().enabled = true;
            babyChick.GetComponent<FollowMovements>().enabled = true;
        }

        if (collision.gameObject == leaveTrigger && readyToGoWithBird == true)
        {
            leavePrompt.SetActive(false);
        }

        if (collision.gameObject == guideTrigger && readyToGoWithBird == true)
        {
            playerGuide.SetActive(false);
        }
    }
}
