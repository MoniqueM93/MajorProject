using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    public bool hasPassed;

    public DialogueTrigger enemyDialogueText;
    public GameObject enemyDialogue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            hasPassed = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            enemyDialogue.SetActive(true);
            enemyDialogueText.TriggerDialogue();
        }
    }
}
