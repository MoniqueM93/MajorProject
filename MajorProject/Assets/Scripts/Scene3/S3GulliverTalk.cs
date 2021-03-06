using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S3GulliverTalk : MonoBehaviour
{
    public GameObject talkToChick;
    public DialogueTrigger talkToChickText;

    public GameObject talkToBessie;
    public DialogueTrigger talkToBessieText;

    public GameObject bessieTrigger;
    public GameObject bessiePrompt;

    public OpeningCameraS3 camRef;

    public bool openingTalkS3Done = false;
    public bool hasSpokeToBessie = false;

    public GameObject leaveArea;
    public GameObject leaveCanvas;

    //audio
    public AudioSource bessieSound;

    //Guide for player
    public GameObject guideTrigger;
    public GameObject playerGuide;

    private void FixedUpdate()
    {
        if (camRef.hasFinishedMove == true && openingTalkS3Done == false)
        {
            talkToChick.SetActive(true);
            talkToChickText.TriggerDialogue();
            openingTalkS3Done = true;
        }

        if (openingTalkS3Done == true)
        {
            talkToChick.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == bessieTrigger)
        {
            bessiePrompt.SetActive(true);
        }

        if (collision.gameObject == leaveArea && hasSpokeToBessie == true)
        {
            leaveCanvas.SetActive(true);
        }

        if (collision.gameObject == guideTrigger && hasSpokeToBessie == true)
        {
            playerGuide.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == bessieTrigger)
        {

            if (Input.GetKey(KeyCode.W))
            {
                hasSpokeToBessie = true;
                bessieSound.Play();
                talkToBessie.SetActive(true);
                talkToBessieText.TriggerDialogue();
                bessiePrompt.SetActive(false);
                leaveArea.SetActive(true);
            }
        }

        if (collision.gameObject == leaveArea && Input.GetKey(KeyCode.W) && hasSpokeToBessie == true){
            SceneManager.LoadScene("Scene4");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == bessieTrigger)
        {
            bessiePrompt.SetActive(false);
        }

        if(collision.gameObject == leaveArea && hasSpokeToBessie == true)
        {
            leaveCanvas.SetActive(false);
        }

        if (collision.gameObject == guideTrigger && hasSpokeToBessie == true)
        {
            playerGuide.SetActive(false);
        }
    }
}
