using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GulliverSelfDialogue : MonoBehaviour
{
    public GameObject selfDialogue1;

    public OpeningCamS2 cameraRef;
    public DialogueTrigger selfDialogue1Text;
    public bool openingTalkDoneS2 = false;

    private void FixedUpdate()
    {
        if (cameraRef.hasFinishedMove == true && openingTalkDoneS2 == false)
        {
            selfDialogue1.SetActive(true);
            selfDialogue1Text.TriggerDialogue();
        }

        if (openingTalkDoneS2 == true)
        {
            selfDialogue1.SetActive(false);

        }
    }
}
