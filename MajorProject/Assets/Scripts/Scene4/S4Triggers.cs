using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S4Triggers : MonoBehaviour
{
    public GameObject doorTrigger;
    public GameObject doorPrompt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == doorTrigger)
        {
            doorPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == doorTrigger)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                SceneManager.LoadScene("Scene5");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorPrompt.SetActive(false);
    }
}
