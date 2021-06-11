using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float widthNumber;
    public float heightNumber;


    // Start is called before the first frame update
    void Start()
{
        target = playermove.instance.transform;
    }

    // Update is called once per frame 
   void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x, -widthNumber, widthNumber),
            Mathf.Clamp(target.position.y,  -heightNumber, heightNumber),
            transform.position.z);
    }
}
