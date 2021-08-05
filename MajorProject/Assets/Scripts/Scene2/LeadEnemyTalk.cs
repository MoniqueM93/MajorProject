using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeadEnemyTalk : MonoBehaviour
{
    public Enemy shootingHasStarted;

    public bool talkingIsDone = false;

    // Update is called once per frame
    void Update()
    {
        if (shootingHasStarted.isShooting == true)
        {
            talkingIsDone = true;
        }
    }
}
