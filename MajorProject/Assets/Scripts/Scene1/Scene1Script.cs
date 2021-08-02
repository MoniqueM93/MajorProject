using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Script : MonoBehaviour
{
    public bool foodPickedUp = false;
    public GameObject theFood;

    private void OnTriggerEnter2D(Collider2D foodTrigger)
    {
        if (theFood != null)
        {
            foodPickedUp = false;
        }
        else if (theFood = null)
        {
            foodPickedUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foodPickedUp = false;
    }
}