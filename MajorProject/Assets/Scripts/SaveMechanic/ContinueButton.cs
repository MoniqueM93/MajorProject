using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    //when the player hits load game

    private int sceneToContinue;
    public void ContinueGame ()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");

        if (sceneToContinue != 0)
            SceneManager.LoadScene(sceneToContinue);
        else
            return;
    }
}
