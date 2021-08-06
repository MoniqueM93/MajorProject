using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    private playermove player;
    public float moveSpeed;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    public FightTrigger fightTrigger;
    public bool isInjured = false;
    public bool isShooting = false;

    [SerializeField] GameObject firingSeed;
    float fireRate;
    float nextFire;

    public Transform fleeTarget;
    private float fleeSpeed = 7f;

    public bool isFleeing = false;
    public bool enemyGone = false;

    public GameObject postFightDialogue;
    public DialogueTrigger postFightDialogueText;

    Scene currentScene;
    string sceneName;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        player = FindObjectOfType(typeof(playermove)) as playermove;
        moveSpeed = 5f;
        localScale = transform.localScale;

        //to gather scene data
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        GameObject fight = GameObject.FindGameObjectWithTag("FightTriggerTag");

    //    fightTrigger = fight.GetComponent<FightTrigger>();

        //For firing
        fireRate = 7f;
        nextFire = Time.time;
    }

    private void Update()
    {

        if (fightTrigger.hasPassed == true && isInjured == false)
        {
        //    print("Ready to go");
            MoveEnemy();
            TimeToFire();
            isShooting = true;
        }

        if (GameManager.enemyHealth < 10 && isInjured == true)
        {
            TimeToFlee();
            isShooting = false;
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

        if (GameManager.enemyHealth < 10)
        {
            isInjured = true;
        }
    }

    public void TimeToFlee()
    {
        if (isInjured == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, fleeTarget.position, fleeSpeed * Time.deltaTime);
            isFleeing = true;
            moveSpeed = 15f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WayPoint"))
        {
            print("I have collided");
            gameObject.SetActive(false);

            if (sceneName == "Scene2")
            {
                postFightDialogue.SetActive(true);
                postFightDialogueText.TriggerDialogue();
            }
        }
    }
}
