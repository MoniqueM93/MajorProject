using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject dialoguePrompt;
    public bool clickToTalk;


    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().dialogueCanvasAppear();
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        Time.timeScale = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            dialoguePrompt.SetActive(true);
            clickToTalk = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (clickToTalk == true && Input.GetKey(KeyCode.UpArrow))
        {
            TriggerDialogue();
            dialoguePrompt.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<DialogueManager>().dialogueCanvasDisappear();
            clickToTalk = false;
            dialoguePrompt.SetActive(false);
        }
    }

}