using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GulliverSelfDialogue : MonoBehaviour
{
    public GameObject selfDialogue1;

    public OpeningCamS2 cameraRef;
    public DialogueTrigger selfDialogue1Text;
    public bool openingTalkDoneS2 = false;

    public GameObject postChickDialogue;
    public DialogueTrigger postChickDialogueText;
    public GameObject chickTalkPrompt;

    public EnemyDialogueS2 TriggerRef;

    public GameObject babyRef;

    public GameObject nestPrompt;
    public GameObject nestTrigger;
    public GameObject nestTalk;
    public DialogueTrigger nestTalkText;

    public bool hasGotBaby = false;

    public GameObject emptyNestPrompt;
    public GameObject emptyNestTrigger;
    public GameObject emptyNestTalk;
    public DialogueTrigger emptyNextTalkText;


    private void FixedUpdate()
    {
        if (cameraRef.hasFinishedMove == true && openingTalkDoneS2 == false)
        {
            selfDialogue1.SetActive(true);
            selfDialogue1Text.TriggerDialogue();
        }

        if (openingTalkDoneS2 == true)
        {
            selfDialogue1.SetActive(false);

        }

        if(hasGotBaby == true)
        {
            emptyNestTrigger.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == TriggerRef.postFightChickTrigger)
        {
            chickTalkPrompt.SetActive(true);
        }

        if (collision.gameObject == nestTrigger && hasGotBaby == true)
        {
            nestPrompt.SetActive(true);
        }

        if(collision.gameObject == emptyNestTrigger)
        {
            emptyNestPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == TriggerRef.postFightChickTrigger)
        {
            if (Input.GetKey(KeyCode.W))
            {
                hasGotBaby = true;
                TriggerRef.postFightChickTrigger.SetActive(false);
                chickTalkPrompt.SetActive(false);
                postChickDialogue.SetActive(true);
                postChickDialogueText.TriggerDialogue();

                babyRef.GetComponent<FollowCode>().enabled = true;
                babyRef.GetComponent<FollowMovements>().enabled = true;
            }
        }

        if (collision.gameObject == nestTrigger && hasGotBaby == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                nestTalk.SetActive(true);
                nestTalkText.TriggerDialogue();
                nestPrompt.SetActive(false);
                StartCoroutine("changeScene");
            }
        }

        if(collision.gameObject == emptyNestTrigger)
        {
            if (Input.GetKey(KeyCode.W)){
                emptyNestTalk.SetActive(true);
                emptyNextTalkText.TriggerDialogue();
                emptyNestPrompt.SetActive(false);
            }
        }
    }

    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Scene3");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == TriggerRef.postFightChickTrigger)
        {
            chickTalkPrompt.SetActive(false);
        }

        if (collision.gameObject == nestTrigger && hasGotBaby == true)
        {
            nestPrompt.SetActive(false);
        }

        if(collision.gameObject == emptyNestTrigger)
        {
            emptyNestPrompt.SetActive(false);
        }
    }
}
