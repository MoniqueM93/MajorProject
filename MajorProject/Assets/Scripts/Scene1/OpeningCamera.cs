using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCamera : MonoBehaviour
{
    private Vector3 Target;
    private Vector3 openingCameraPosition;
    private bool isLerping;
    public float Speed;
    private float timer;
    public float CameraPanTime = 1.5f;

    public float moveToX;
    public float moveToY;

    public bool hasFinishedMove = false;

    public DialogueTrigger textTrigger;

    public GameObject tutorialScreen;

    public void cameraPosition()
    {
        isLerping = true;
        openingCameraPosition = new Vector3(1, 12, -10);
        Target = new Vector3(moveToX, moveToY, -10);
    }

    public void BeginButton()
    {
        cameraPosition();
        tutorialScreen.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (isLerping)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(openingCameraPosition, Target, timer / CameraPanTime);
        }

//        if (Input.GetKey(KeyCode.M))
//        {
//            cameraPosition();
//        }

        if (gameObject.transform.position == Target)
        {
            hasFinishedMove = true;
        }

        if (hasFinishedMove == true)
        {
            gameObject.SetActive(false);
 //           textTrigger.TriggerDialogue();
        }
    }
}
