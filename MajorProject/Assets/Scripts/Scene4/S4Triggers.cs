using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                print("Enter pet store");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        doorPrompt.SetActive(false);
    }
}
