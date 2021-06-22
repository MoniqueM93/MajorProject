using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEnemySeed : MonoBehaviour
{
    float moveSpeed = 7f;
    public Rigidbody2D enemySeedRB;
    playermove aimTarget;
    Vector2 moveDirection;
    public float seedLifetime = 5f;

    private void Start()
    {
        enemySeedRB = GetComponent<Rigidbody2D>();
        aimTarget = GameObject.FindObjectOfType<playermove>();
        moveDirection = (aimTarget.transform.position - transform.position).normalized * moveSpeed;
        enemySeedRB.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, seedLifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.playerHealth -= 5;
            Destroy(gameObject);
        }
    }
}
