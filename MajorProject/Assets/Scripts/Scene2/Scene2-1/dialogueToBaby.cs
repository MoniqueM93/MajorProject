using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueToBaby : MonoBehaviour
{
    private Vector3 localScale;

    public GameObject talkAtStart;
    public DialogueTrigger talkAtStartText;

    public GameObject talkAtNest;
    public DialogueTrigger talkAtNestText;

    public DialogueManager talkEndRef;

    public GameObject nestTriggers;

    public bool nestHasCollided = false;

    private void Start()
    {
        localScale = transform.localScale;

        talkAtStart.SetActive(true);
        talkAtStartText.TriggerDialogue();
    }

    private void Update()
    {
        if (talkEndRef.talkHasEnded == false)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        } else if (talkEndRef.talkHasEnded == true)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == nestTriggers)
        {
            nestHasCollided = true;
            talkAtNest.SetActive(true);
            talkAtNestText.TriggerDialogue();
        }
    }
}
