using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJump : MonoBehaviour
{
    public bool birdIsThere = false;
    public float dropTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            birdIsThere = true;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            birdIsThere = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S) && birdIsThere == true)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            dropTime = 1f;
        } else if (birdIsThere == false){
            dropTime -= Time.deltaTime;

            if (dropTime <= 0 && birdIsThere == false)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                dropTime = 0f;
            }
        }


        //    if (Input.GetKey(KeyCode.DownArrow))
        //        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        //    else
        //        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
