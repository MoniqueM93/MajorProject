using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTrigger : MonoBehaviour
{
    public bool hasPassed;

    public DialogueTrigger enemyDialogueText;
    public GameObject enemyDialogue;

    Scene currentScene;
    string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            hasPassed = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;

            if (sceneName == "Scene2")
            {
                enemyDialogue.SetActive(true);
                enemyDialogueText.TriggerDialogue();
            }
        }
    }
}
