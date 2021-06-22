using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private playermove player;
    public float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    public FightTrigger fightTrigger;

    [SerializeField] GameObject firingSeed;
    float fireRate;
    float nextFire;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(playermove)) as playermove;
        moveSpeed = 5f;
        localScale = transform.localScale;

        GameObject fight = GameObject.FindGameObjectWithTag("FightTriggerTag");

    //    fightTrigger = fight.GetComponent<FightTrigger>();

        //For firing
        fireRate = 7f;
        nextFire = Time.time;
    }

    private void Update()
    {
        if(fightTrigger.hasPassed == true)
        {
            print("Ready to go");
            MoveEnemy();
            TimeToFire();
        }
    }

    private void MoveEnemy()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        enemyRB.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * moveSpeed;
    }

    void TimeToFire()
    {
        if (Time.time > nextFire)
        {
            print("Fire");
            Instantiate(firingSeed, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }

    private void LateUpdate()
    {
        if (enemyRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        } else if (enemyRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
        }
    }

    public void OnTriggerEnter2D(Collider2D collisionBullet)
    {
        if (collisionBullet.gameObject.tag.Equals("Bullet"))
        {
            GameManager.enemyHealth -= 10;
        }

        if (GameManager.enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
