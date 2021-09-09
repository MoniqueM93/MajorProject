using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1PickUp : MonoBehaviour
{
    public bool beenStolen = false;
    public GameObject interactPrompt;

    Scene1Script foodTaken;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            beenStolen = true;
            interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (beenStolen = true && Input.GetKey(KeyCode.W))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactPrompt.SetActive(false);
    }
}
