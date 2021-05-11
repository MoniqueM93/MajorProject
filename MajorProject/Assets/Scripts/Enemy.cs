using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemyRB;
    public float healthBar = 50;
    public float deathNum = 0;
    // Start is called before the first frame update
    void Start()
    {

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
    }
}
