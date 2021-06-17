using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class FriendDialogue : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText, nameText;
    [SerializeField] private string myDialogue, friendName;
    [SerializeField] private GameObject dialogueCanvas;
    [SerializeField] private bool playOnce;
    private bool playedDialogue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playOnce && playedDialogue) return;

        dialogueText.text = myDialogue;
        nameText.text = friendName;
        dialogueCanvas.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (playOnce && playedDialogue) return;

        dialogueCanvas.SetActive(false);

        if (playOnce)
        {
            playedDialogue = true;
        }
    }
}
