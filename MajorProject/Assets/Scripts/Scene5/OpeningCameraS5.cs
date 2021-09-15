using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCameraS5 : MonoBehaviour
{
    private Vector3 Target;
    private Vector3 openingPosition;
    private bool isLerping;
    private float timer;
    public float speed;
    public float CamPanTime = 1.5f;

    public float moveToX;
    public float moveToY;

    public bool hasFinishedMove = false;

    private void Start()
    {
        cameraPosition();
        Time.timeScale = 1;
    }

    public void cameraPosition()
    {
        isLerping = true;
        openingPosition = new Vector3(3, 1, -20);
        Target = new Vector3(moveToX, moveToY, -10);
    }

    private void FixedUpdate()
    {
        if (isLerping)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(openingPosition, Target, timer / CamPanTime);
        }

        if (gameObject.transform.position == Target)
        {
            hasFinishedMove = true;
        }

        if (hasFinishedMove == true)
        {
            gameObject.SetActive(false);
        }
    }
}
