using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S14Triggers : MonoBehaviour
{
    public GameObject friendAChar;
    public GameObject friendATalk;
    public DialogueTrigger friendATalkText;
    public GameObject friendTalkPrompt;
    public bool famTalkDone = false;

    public GameObject friendATalk2;
    public DialogueTrigger friendATalk2Text;

    //baby chick refs
    public GameObject babyChick;
    public GameObject babyChickAnim;

    public GameObject catChar;

    public GameObject dogChar;

    public GameObject famChar;
    public DialogueTrigger famTalkText;
    public GameObject famTalk;
    public GameObject famTalkPrompt;

    public GameObject friendBlocks;

    public bool leaveIsActive = false;
    public GameObject leaveArea;
    public GameObject leavePrompt;

    public playermove groundedRef;

    public AudioSource catMeow;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (leaveIsActive == true)
        {
            leaveArea.SetActive(true);
        }
    }

    // to allow the chick to catch up when talking to the family.
    IEnumerator ToTalkToFamily()
    {
        yield return new WaitForSeconds(0);
        famTalk.SetActive(true);
        famTalkText.TriggerDialogue();
        babyChick.GetComponent<FollowCode>().enabled = false;
        babyChick.GetComponent<FollowMovements>().enabled = false;
        babyChickAnim.GetComponent<Animator>().enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == friendAChar)
        {
            friendTalkPrompt.SetActive(true);
        }

        if (collision.gameObject == famChar && famTalkDone == false)
        {
            famTalkPrompt.SetActive(true);
        }

        //for enemies
        if (collision.gameObject == catChar)
        {
            catMeow.Play();
            GameManager.playerHealth -= 5;
            catChar.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject == dogChar)
        {
            GameManager.playerHealth -= 5;
            catChar.GetComponent<BoxCollider2D>().enabled = false;
        }

        //to leave scene
        if (collision.gameObject == leaveArea && leaveIsActive == true)
        {
            leavePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == friendAChar)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendATalk.SetActive(true);
                friendATalkText.TriggerDialogue();
                friendBlocks.SetActive(false);
            }
        }

        if (collision.gameObject == friendAChar && famTalkDone == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                friendATalk2.SetActive(true);
                friendATalk2Text.TriggerDialogue();
                leaveIsActive = true;
            }
        }

        if(collision.gameObject == famChar && groundedRef.grounded == true)
        {
            if (Input.GetKey(KeyCode.W) && famTalkDone == false)
            {
                famTalkDone = true;
                StartCoroutine("ToTalkToFamily");
            }
        }

        //when leaving area
        if (collision.gameObject == leaveArea && leaveIsActive == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene15");
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

        // for the enemies
//        if (collision.gameObject == catChar)
//        {
//            catChar.GetComponent<BoxCollider2D>().enabled = true;
//       }

        //to leave scene
        if (collision.gameObject == leaveArea && leaveIsActive == true)
        {
            leavePrompt.SetActive(false);
        }
    }
}
