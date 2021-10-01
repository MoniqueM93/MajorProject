using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToRotate : MonoBehaviour
{
    public Enemy fightRef;

    public Transform birdRotate;

    private float willTurn;

    private void Start()
    {
        willTurn = birdRotate.localScale.x;
    }

    private void Update()
    {
        if (fightRef.isShooting == false)
        {
            birdRotate.localScale = new Vector3(willTurn, birdRotate.localScale.y, birdRotate.localScale.z);
        } else if (fightRef.isShooting == true)
        {
            birdRotate.localScale = new Vector3(-willTurn, birdRotate.localScale.y, birdRotate.localScale.z);
        }
    }
}
