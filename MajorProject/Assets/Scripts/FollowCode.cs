using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCode : MonoBehaviour
{
    public GameObject leader; // the game object to follow - assign in inspector
    public int steps; // number of steps to stay behind - assign in inspector
    private Queue<Vector3> record = new Queue<Vector3>();
    private Vector3 lastRecord;

    // Update is called once per frame
    void FixedUpdate()
    {
        // record position of leader
        record.Enqueue(leader.transform.position);

        // remove last position from the record and use it for our own
        if (record.Count > steps)
        {
            this.transform.position = record.Dequeue();
        }
    }
}




