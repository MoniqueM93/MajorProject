using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if(GameManager.playerHealth < 100)
            {
                GameManager.playerHealth += 10;
                Destroy(gameObject);
            }
        }
    }
}
