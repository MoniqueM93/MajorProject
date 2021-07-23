using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovements : MonoBehaviour
{
    public bool isFlying = false;
    public bool isLanding;
    public bool onTheGround;
    public bool isWalking;

    public playermove playerRef;
    public Transform chickAnimationGO;
    float chickAnimationGOInitial;
    Animator chickAnim;


    private void Start()
    {
        chickAnimationGOInitial = chickAnimationGO.localScale.x;
        chickAnim = GetComponentInChildren<Animator>();
    }



    private void Update()
    {
       if (playerRef.currentSpeed > 0)
      {
            chickAnimationGO.localScale = new Vector3(chickAnimationGOInitial, chickAnimationGO.localScale.y, chickAnimationGO.localScale.z);
            isWalking = true;
            chickAnim.SetBool("chickIsWalking", true);
        }
        else if (playerRef.currentSpeed < 0)
        {
            chickAnimationGO.localScale = new Vector3(-chickAnimationGOInitial, chickAnimationGO.localScale.y, chickAnimationGO.localScale.z);
            isWalking = true;
            chickAnim.SetBool("chickIsWalking", true);
        }

        if (playerRef.currentSpeed == 0)
        {
            isWalking = false;
            chickAnim.SetBool("chickIsWalking", false);
        }

        if (playerRef.verticalSpeed > 0)
        {
            isWalking = false;
            chickAnim.SetBool("chickIsWalking", false);

            isFlying = true;
            chickAnim.SetBool("chickIsFlying", true);

            onTheGround = false;
        } else if (playerRef.verticalSpeed < 0)
        {
            isWalking = false;
            chickAnim.SetBool("chickIsWalking", false);

            isLanding = true;
            chickAnim.SetBool("chickIsLanding", true);

            onTheGround = false;

            isFlying = false;
            chickAnim.SetBool("chickIsFlying", false);
        }

       if (playerRef.grounded == true)
        {
            onTheGround = true;

            isLanding = false;
            chickAnim.SetBool("chickIsLanding", false);

            isFlying = false;
            chickAnim.SetBool("chickIsFlying", false);
        }



    }
}
