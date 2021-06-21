using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public float healthBar = 50;
    public float deathNum = 0;

    public bool hasSpottedPlayer;
    public CapsuleCollider2D radiusCollide;
    public BoxCollider2D bodyCollide;

    // Start is called before the first frame update
    void Start()
    {
        radiusCollide = gameObject.GetComponent<CapsuleCollider2D>();
        bodyCollide = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D Enemy)
    {
        if (Enemy.tag == "Bullet" && healthBar <= 10)
        {
            Destroy(gameObject);
        }
        else
        {
            healthBar -= 10;
        }

        if (Enemy.gameObject.tag.Equals("Player") && hasSpottedPlayer == false)
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            GameManager.playerHealth += 10;
            hasSpottedPlayer = true;
        }
    }

}
