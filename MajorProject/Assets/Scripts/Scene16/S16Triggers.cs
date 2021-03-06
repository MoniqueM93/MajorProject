using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S16Triggers : MonoBehaviour
{
    public GameObject eadieChar;
    public GameObject eadieTalk;
    public DialogueTrigger eadieTalkText;
    public GameObject eadiePrompt;

    public GameObject eadieCall;
    public DialogueTrigger eadieCallText;

    public GameObject leaveArea;
    public GameObject leaveAreaPrompt;

    public bool eadieHasCalled = false;
    public bool hasSpokenToEadie = false;

    public bool changeScene = false;

    private void Start()
    {
        Time.timeScale = 1;

        if (eadieHasCalled == false)
        {
            StartCoroutine("EadieCallOver");
        }
    }

    IEnumerator EadieCallOver()
    {
        yield return new WaitForSeconds(1);
        eadieCall.SetActive(true);
        eadieCallText.TriggerDialogue();
        eadieHasCalled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == eadieChar)
        {
            eadiePrompt.SetActive(true);
        }

        if(collision.gameObject == leaveArea)
        {
            leaveAreaPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == eadieChar)
        {
            if (Input.GetKey(KeyCode.W))
            {
                eadieTalk.SetActive(true);
                eadieTalkText.TriggerDialogue();
                leaveArea.SetActive(true);
                eadiePrompt.SetActive(false);
            }
        }

        if(collision.gameObject == leaveArea)
        {
            if (Input.GetKey(KeyCode.W) && changeScene == false)
            {
                changeScene = true;
                SceneManager.LoadScene("Scene17");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == eadieChar)
        {
            eadiePrompt.SetActive(false);
        }

        if (collision.gameObject == leaveArea)
        {
            leaveAreaPrompt.SetActive(false);
        }
    }
}
