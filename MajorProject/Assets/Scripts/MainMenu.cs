using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject tutorialMenu;

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
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
