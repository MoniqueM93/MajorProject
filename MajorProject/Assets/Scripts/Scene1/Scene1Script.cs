using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1PickUp : MonoBehaviour
{
    public bool foodStolen;
    public bool dialogueSecondBegin;
    private Scene1Script pickupRef;

    private void Update()
    {
        if (foodStolen == true)
        {
            dialogueSecondBegin = true;
        }
    }
}