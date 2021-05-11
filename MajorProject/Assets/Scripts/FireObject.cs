using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObject : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(transform.right * transform.localScale.x * Time.deltaTime);
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            return;

        Destroy(gameObject);
    }
}
