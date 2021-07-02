using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFight : MonoBehaviour
{
    public bool hasSpottedPlayer;
    public CapsuleCollider2D radiusCollide;

    // Start is called before the first frame update
    void Start()
    {
        radiusCollide = gameObject.GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D radiusCol)
    {
        if (radiusCol.gameObject.tag.Equals("Player"))
        {
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        //    GameManager.playerHealth += 10;
            hasSpottedPlayer = true;
        }
    }
}
