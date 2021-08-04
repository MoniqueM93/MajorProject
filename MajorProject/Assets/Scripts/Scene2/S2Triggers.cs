using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Triggers : MonoBehaviour
{
    public GameObject fightBlock;
    public GameObject fightBlockTrigger;

    public bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == fightBlockTrigger)
        {
           hasCollided = true;
           fightBlock.SetActive(false);
        }
    }
}
