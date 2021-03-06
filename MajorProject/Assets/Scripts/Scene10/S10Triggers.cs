using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S10Triggers : MonoBehaviour
{
    //for the talking
    public GameObject thisFriendA;
    public GameObject friendATalk;
    public DialogueTrigger friendATalkText;
    public GameObject friendAPrompt;

    public GameObject thisFriendB;
    public GameObject friendBTalk;
    public DialogueTrigger friendBTalkText;
    public GameObject friendBPrompt;

    public bool isTalkDone = false;

    public bool canEnterPetStore = false;

    //to enter the pet store
    public GameObject petDoor;
    public GameObject doorPrompt;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == thisFriendA)
        {
            friendAPrompt.SetActive(true);
        }

        if(collision.gameObject == thisFriendB)
        {
            friendBPrompt.SetActive(true);
        }

        if (collision.gameObject == petDoor)
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == thisFriendA)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                isTalkDone = true;
                friendAPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == thisFriendB)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
                friendBPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == petDoor)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene11");
                canEnterPetStore = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == thisFriendA)
        {
            friendAPrompt.SetActive(false);
        }

        if (collision.gameObject == thisFriendB)
        {
            friendBPrompt.SetActive(false);
        }

        if (collision.gameObject == petDoor)
        {
            doorPrompt.SetActive(false);
        }
    }
}
