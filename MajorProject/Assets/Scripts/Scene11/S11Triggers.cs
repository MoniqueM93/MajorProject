using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S11Triggers : MonoBehaviour
{
    public GameObject eadieChar;
    public GameObject eadieTalk;
    public DialogueTrigger eadieTalkText;
    public GameObject eadiePrompt;
    public bool spokeToEadie = false;

    public GameObject loveBirds;
    public GameObject loveBirdsTalk;
    public DialogueTrigger loveBirdsTalkText;
    public GameObject loveBirdsPrompt;
    public bool spokeToLoveBirds = false;

    public GameObject loveBirdsBlocked;

    public GameObject leaveTalk;
    public DialogueTrigger leaveTalkText;

    public GameObject storeDoor;
    public GameObject doorPrompt;
    public bool aboutToLeave = false;

    public bool talkToChick = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(spokeToEadie == true)
        {
            loveBirdsBlocked.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == eadieChar)
        {
            eadiePrompt.SetActive(true);
        }

        if (collision.gameObject == loveBirds && spokeToEadie == true)
        {
            loveBirdsPrompt.SetActive(true);
        }

        if (collision.gameObject == leaveTalk && talkToChick == false)
        {
            leaveTalk.SetActive(true);
            leaveTalkText.TriggerDialogue();
            talkToChick = true;
            storeDoor.SetActive(true);
        }

        if (collision.gameObject == storeDoor && aboutToLeave == false)
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject == eadieChar)
        {
            if (Input.GetKey(KeyCode.W) && spokeToEadie == false)
            {
                eadieTalk.SetActive(true);
                eadieTalkText.TriggerDialogue();
                spokeToEadie = true;
                eadieChar.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (collision.gameObject == loveBirds && spokeToEadie == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                loveBirdsTalk.SetActive(true);
                loveBirdsTalkText.TriggerDialogue();
                loveBirds.GetComponent<BoxCollider2D>().enabled = false;
                spokeToLoveBirds = true;
                leaveTalk.GetComponent<BoxCollider2D>().enabled = true;
            }
        }

        if (collision.gameObject == storeDoor && aboutToLeave == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene12");
                aboutToLeave = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == eadieChar)
        {
            eadiePrompt.SetActive(false);
        }

        if (collision.gameObject == loveBirds && spokeToEadie == true)
        {
            loveBirdsPrompt.SetActive(false);
        }

        if (collision.gameObject == storeDoor && aboutToLeave == false)
        {
            doorPrompt.SetActive(false);
        }
    }
}
