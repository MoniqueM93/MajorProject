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

    public GameObject leaveArea;
    public GameObject leaveCanvas;

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

        if (collision.gameObject == leaveArea)
        {
            leaveCanvas.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == bessieTrigger)
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {
                talkToBessie.SetActive(true);
                talkToBessieText.TriggerDialogue();
                bessiePrompt.SetActive(false);
                leaveArea.SetActive(true);
            }
        }

        if (collision.gameObject == leaveArea && Input.GetKey(KeyCode.UpArrow)){
            SceneManager.LoadScene("Scene4");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == leaveArea)
        {
            leaveCanvas.SetActive(false);
        }
    }
}
