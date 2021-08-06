using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForBaby : MonoBehaviour
{
    public DialogueManager talkingEndRef;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<FollowCode>().enabled = false;
        gameObject.GetComponent<FollowMovements>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (talkingEndRef.talkHasEnded == true)
        {
            gameObject.GetComponent<FollowCode>().enabled = true;
            gameObject.GetComponent<FollowMovements>().enabled = true;
        }
    }
}
