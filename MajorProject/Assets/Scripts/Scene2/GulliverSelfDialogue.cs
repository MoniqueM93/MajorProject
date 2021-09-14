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
                StartCoroutine("changeScene");
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
    }
}
