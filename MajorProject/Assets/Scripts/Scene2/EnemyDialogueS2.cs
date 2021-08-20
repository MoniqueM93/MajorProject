using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDialogueS2 : MonoBehaviour
{
    public GameObject enemyDialogue;

    public S2Triggers triggerRef;
    public DialogueTrigger enemyDialogueText;

    //public LeadEnemyTalk ifTalkingDone;


    private void FixedUpdate()
    {
     //   if (triggerRef.hasCollided == true && ifTalkingDone.talkingIsDone == false)
     //   {
     //       enemyDialogue.SetActive(true);
     //       enemyDialogueText.TriggerDialogue();
    //    }

     //   if (triggerRef.hasCollided == true && ifTalkingDone.talkingIsDone == true)
     //   {
     //       enemyDialogue.SetActive(false);
     //   }
    }

}
