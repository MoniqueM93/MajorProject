using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FightTriggerOP : MonoBehaviour
{
    public bool hasPassedOP;

    Scene currentScene;
    string sceneName;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (sceneName !="Scene2" && collision.gameObject.tag.Equals("Player"))
        {
            hasPassedOP = true;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}