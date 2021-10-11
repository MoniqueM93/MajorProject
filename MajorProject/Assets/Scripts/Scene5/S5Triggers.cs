using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S5Triggers : MonoBehaviour
{
    public OpeningCameraS5 S5CamRef;

    public GameObject eadieTrigger;

    public GameObject eadieCallOver;
    public DialogueTrigger eadieCallOverText;

    public GameObject EadieDialogue;
    public DialogueTrigger EadieDialogueText;
    public GameObject EadieTalkPrompt;

    public GameObject cageBlock;

    //when it's time to leave
    public bool readyToLeave = false;
    public GameObject sceneDoor;
    public GameObject leavePrompt;

    //for the fish bone
    public GameObject fishBoneCollect;
    public GameObject boneCollectPrompt;
    public bool hasFishBone = false;

    //Eadie leave talk
    public GameObject eadieLeaveTalk;
    public DialogueTrigger eadieLeaveTalkText;

    public bool playOpeningOnce = false;

    public bool firstTalkDone = false;

    //Audio files
    public AudioSource swipeSound;
    public AudioSource eadieSounds;

    private void FixedUpdate()
    {
        if (S5CamRef.hasFinishedMove == true && playOpeningOnce == false)
        {
            playOpeningOnce = true;
            eadieCallOver.SetActive(true);
            eadieCallOverText.TriggerDialogue();
        }

        if (S5CamRef.hasFinishedMove == true && playOpeningOnce == true)
        {
            eadieCallOver.SetActive(false);
        }

        if (readyToLeave == true)
        {
            sceneDoor.SetActive(true);
            EadieTalkPrompt.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Eadie talking
        if (collision.gameObject == eadieTrigger && firstTalkDone == false)
        {
            EadieTalkPrompt.SetActive(true);
        }

        //to pick up the fish bone
        if (collision.gameObject == fishBoneCollect)
        {
            boneCollectPrompt.SetActive(true);
        }

        //to speak to eadie when leaving
        if (collision.gameObject == eadieTrigger && hasFishBone == true)
        {
            EadieTalkPrompt.SetActive(true);
        }

        //collision with the door
        if (collision.gameObject == sceneDoor)
        {
            leavePrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //to talk to eadie
        if (collision.gameObject == eadieTrigger && firstTalkDone == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                eadieSounds.Play();
                EadieDialogue.SetActive(true);
                EadieDialogueText.TriggerDialogue();
                EadieTalkPrompt.SetActive(false);
                cageBlock.SetActive(false);
                firstTalkDone = true;
            }
        }

        //to pick up the fish bone
        if (collision.gameObject == fishBoneCollect)
        {
            if (Input.GetKey(KeyCode.W))
            {
                swipeSound.Play();
                Destroy(fishBoneCollect);
                hasFishBone = true;
            }
        }

        if(collision.gameObject == eadieTrigger && hasFishBone == true && readyToLeave == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                eadieSounds.Play();
                EadieTalkPrompt.SetActive(false);
                eadieLeaveTalk.SetActive(true);
                eadieLeaveTalkText.TriggerDialogue();
                readyToLeave = true;
            }
        }

        //collision with the door
        if (collision.gameObject == sceneDoor)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //print("change scene");
                SceneManager.LoadScene("Scene6");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EadieTalkPrompt.SetActive(false);
        
        if  (collision.gameObject ==  eadieTrigger && firstTalkDone == true)
        {
            eadieSounds.Stop();
            EadieDialogue.SetActive(false);
        }

        //collision with the door
        if (collision.gameObject == sceneDoor)
        {
            leavePrompt.SetActive(false);
        }
    }
}
