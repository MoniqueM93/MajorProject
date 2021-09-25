using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playermove : MonoBehaviour
{
    public Rigidbody2D myRB;
    public float maxSpeed;
    public float acceleration;
    public float currentSpeed;
    public float verticalSpeed;
    public float jumpforce;
    public bool grounded;
    public Transform animatorGO;
    float animatorGOInitial;
    Animator anim;
    public Transform respawnPoint;

    public static playermove instance;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        animatorGOInitial = animatorGO.localScale.x;
        anim = GetComponentInChildren<Animator>();
        respawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = myRB.velocity.x;

        verticalSpeed = myRB.velocity.y;

        float move = Input.GetAxis("Horizontal"); //checking for left and right input on keyboard or controller
 //       print("move is " + move);

        //Flip Animator GameObject based on input
        if (move > 0)
        {
            animatorGO.localScale = new Vector3(animatorGOInitial, animatorGO.localScale.y, animatorGO.localScale.z);
        }
        else if (move < 0)
        {
            animatorGO.localScale = new Vector3(-animatorGOInitial, animatorGO.localScale.y, animatorGO.localScale.z);
        }

        //end flipping animator

        if (Mathf.Abs(currentSpeed) < maxSpeed)
        {
            myRB.AddRelativeForce(new Vector2(move * acceleration, 0)); //Adding Relative force to the rigidbody2d depending on the input vector
        }

        //left and right move code ends

        //animator speed code
        anim.SetFloat("speed", Mathf.Abs(currentSpeed + move));
        anim.SetFloat("vspeed", verticalSpeed);
        //end animator speed code

        //jump code begins

        if (Input.GetKeyDown("space"))
        {
            myRB.AddForce(new Vector2(0, jumpforce));
        }

        //jump code ends
    }
    //grounded check code starts

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bird")
        {
            grounded = true;
            anim.SetBool("grounded", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "bird")
        {
            grounded = false;
            anim.SetBool("grounded", false);
        }
    }

    //grounded check code ends

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameManager.playerHealth -= 10;
        }

        if (GameManager.playerHealth == 0)
        {
            Death();
        }
    }

    private void Death()
    {
//        gameObject.transform.position = respawnPoint.position;
        GameManager.playerHealth = 100;
 //       AmmoText.ammoAmount = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}