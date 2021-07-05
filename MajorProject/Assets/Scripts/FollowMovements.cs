using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovements : MonoBehaviour
{
    public bool isFlying = false;
    public bool isLanding;
    public bool onTheGround;

    public playermove playerRef;
    public Transform chickAnimationGO;
    float chickAnimationGOInitial;



    private void Start()
    {
        chickAnimationGOInitial = chickAnimationGO.localScale.x;
    }



    private void Update()
    {
       if (playerRef.currentSpeed > 0)
      {
            chickAnimationGO.localScale = new Vector3(chickAnimationGOInitial, chickAnimationGO.localScale.y, chickAnimationGO.localScale.z);
        }
        else if (playerRef.currentSpeed < 0)
        {
            chickAnimationGO.localScale = new Vector3(-chickAnimationGOInitial, chickAnimationGO.localScale.y, chickAnimationGO.localScale.z);
        }

       if (playerRef.verticalSpeed > 0)
        {
            isFlying = true;
            onTheGround = false;
        } else if (playerRef.verticalSpeed < 0)
        {
            isLanding = true;
            onTheGround = false;
            isFlying = false;
        }

       if (playerRef.grounded == true)
        {
            onTheGround = true;
            isLanding = false;
            isFlying = false;
        }
    }
}
