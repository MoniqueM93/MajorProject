using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDialogueS2 : MonoBehaviour
{
    public GameObject enemyDialogue;

    public S2Triggers triggerRef;
    public DialogueTrigger enemyDialogueText;

    //public LeadEnemyTalk ifTalkingDone;

    public GameObject postFightDialogue;
    public DialogueTrigger postFightDialogueText;
    public GameObject postFightChickTrigger;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("WayPoint"))
        {
            print("I have collided");
            gameObject.SetActive(false);

            postFightChickTrigger.SetActive(true);

                postFightDialogue.SetActive(true);
                postFightDialogueText.TriggerDialogue();
//                readyToSceneChange = true;
         
        }
    }
}
