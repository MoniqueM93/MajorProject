using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // this is when the user clicks the start button
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
