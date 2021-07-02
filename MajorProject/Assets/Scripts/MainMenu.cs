using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        print("Starting the game");
    }

    public void LoadGame()
    {
        print("Loading the last game");
    }

    public void HowToPlay()
    {
        print("How to play the game");
    }

    public void QuitGame()
    {
        print("Quitting the game");
    }
}
