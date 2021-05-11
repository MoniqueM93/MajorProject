using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7.5f;
    public float flySpeed = 5;
    public Rigidbody2D theRB;
    public GameObject strayBullet;
    public float lifetime = 1f;
    public float fireDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(strayBullet, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        theRB.velocity = transform.right * transform.localScale.x * speed * flySpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            //           Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
