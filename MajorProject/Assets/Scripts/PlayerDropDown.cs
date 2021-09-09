using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropDown : MonoBehaviour
{
    public bool birdOnLedge;
    public float dropTime;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("DropDown"))
        {
            birdOnLedge = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("DropDown"))
        {
            birdOnLedge = false;
        }
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.S) && birdOnLedge == true)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            dropTime = 0.5f;
        } else if (birdOnLedge == false)
        {
            dropTime -= Time.deltaTime;

            if (dropTime <= 0)
            {
                gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                dropTime = 0f;
            }
        }
    }
}
