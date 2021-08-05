using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S2Triggers : MonoBehaviour
{
    public GameObject fightBlock;
    public GameObject fightBlockTrigger;
    public GameObject fightDialogueTrigger;



    public bool hasCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Makes the player collect ammo before fight and unblocks path
        if (collision.gameObject == fightBlockTrigger)
        {
           fightBlock.SetActive(false);
        }
    }
}
