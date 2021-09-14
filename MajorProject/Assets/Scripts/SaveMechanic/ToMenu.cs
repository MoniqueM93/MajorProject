using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    // this will control the MENU BUTTON

    private int currentSceneIndex;

    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(0);
    }
}
