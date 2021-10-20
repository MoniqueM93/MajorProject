using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S13Triggers : MonoBehaviour
{
    //to remove the blocks
    public GameObject openingBlocks;

    public GameObject babyChick;
    public GameObject babyChickAnim;
    public GameObject babyChickInNest;

    public GameObject chickTalk1;
    public DialogueTrigger chickTalk1Text;

    public GameObject chickTalk2;
    public DialogueTrigger chickTalk2Text;

    public bool chickTalk1Done = false;
    public bool chickTalk2Done = false;

    public GameObject chickTalk2Prompt;

    public GameObject bessieChar;
    public GameObject bessieTalk;
    public DialogueTrigger bessieTalkText;
    public bool hasSpokeToBessie = false;
    public GameObject bessiePrompt;

    public bool sceneChange = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    IEnumerator timeToChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Scene14");
    }

    private void Update()
    {
        if (hasSpokeToBessie == true)
        {
            chickTalk2.SetActive(true);
        }

        if (chickTalk2Done == true && sceneChange == false)
        {
            StartCoroutine("timeToChangeScene");
            sceneChange = true;
        }
    }

    IEnumerator WaitToLand()
    {
        yield return new WaitForSeconds(1);
        chickTalk1.SetActive(true);
        chickTalk1Text.TriggerDialogue();
        chickTalk1Done = true;
        babyChick.GetComponent<FollowCode>().enabled = false;
        babyChick.GetComponent<FollowMovements>().enabled = false;
        babyChickAnim.GetComponent<Animator>().enabled = false;
        openingBlocks.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == chickTalk1 && chickTalk1Done == false)
        {
            StartCoroutine("WaitToLand");
        }

        if (collision.gameObject == bessieChar)
        {
            bessiePrompt.SetActive(true);
        }

        if (collision.gameObject == chickTalk2 && hasSpokeToBessie == true)
        {
            chickTalk2Prompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == bessieChar)
        {
            if (Input.GetKey(KeyCode.W))
            {
                bessiePrompt.SetActive(false);
                bessieTalk.SetActive(true);
                bessieTalkText.TriggerDialogue();
                babyChick.SetActive(false);
                babyChickInNest.SetActive(true);
                hasSpokeToBessie = true;
            }
        }

        if (collision.gameObject == chickTalk2 && hasSpokeToBessie == true && sceneChange == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                chickTalk2Prompt.SetActive(false);
                chickTalk2.SetActive(true);
                chickTalk2Text.TriggerDialogue();
                chickTalk2Done = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == bessieChar)
        {
            bessiePrompt.SetActive(false);
        }

        if (collision.gameObject == chickTalk2 && hasSpokeToBessie == true)
        {
            chickTalk2Prompt.SetActive(false);
        }
    }
}
