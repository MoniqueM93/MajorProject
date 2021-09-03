using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (collision.gameObject == petDoor && isTalkDone == true)
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == thisFriendA)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                isTalkDone = true;
            }
        }

        if (collision.gameObject == thisFriendB)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
            }
        }

        if (collision.gameObject == petDoor && isTalkDone == true && canEnterPetStore == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                print("To the next level");
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

        if (collision.gameObject == petDoor && isTalkDone == true)
        {
            doorPrompt.SetActive(false);
        }
    }
}
