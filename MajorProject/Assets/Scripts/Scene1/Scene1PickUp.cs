using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Script : MonoBehaviour
{
    private Scene1PickUp foodItem;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && Input.GetKey(KeyCode.UpArrow))
        {
            print("Has collided");
         //   Destroy(gameObject);
         //   foodItem.foodStolen = true;
        }
    }
}
