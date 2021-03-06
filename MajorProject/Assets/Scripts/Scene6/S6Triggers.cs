using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    //Guides
    public GameObject guideTrigger;
    public GameObject playerGuide;


    //to stop talking in mid air
//    public float talkWait;
//    public playermove isGrounded;
//    public bool talkCanStart = false;

//    IEnumerator ToStartDialogue()
//    {
//        yield return new WaitForSeconds(talkWait);
//        talkCanStart = true;
//    }

//    public void Update()
//    {
//        if(isGrounded.grounded == true)
//        {
//            StartCoroutine("ToStartDialogue");
//        } else if (isGrounded.grounded == false)
//        {
//            talkCanStart = false;
//        }
//    }

    private void Start()
    {
        Time.timeScale = 1;
    }

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

        if (collision.gameObject == guideTrigger)
        {
            playerGuide.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendATalk)
 {
            if (Input.GetKey(KeyCode.W)){
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                friendATextPrompt.SetActive(false);
            }
        }        
        
        if (collision.gameObject == friendBTalk)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendBTalk.SetActive(true);
                friendBTalkText.TriggerDialogue();
                friendBTextPrompt.SetActive(false);
            }
        }

        if (collision.gameObject == leaveTrigger)
        {
            if (Input.GetKey(KeyCode.W) && readyToSwitch == false)
            {
                SceneManager.LoadScene("Scene7");
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

        if (collision.gameObject == guideTrigger)
        {
            playerGuide.SetActive(false);
        }
    }
}
