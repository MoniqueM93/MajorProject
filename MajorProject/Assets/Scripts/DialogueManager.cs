using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    [SerializeField] private GameObject dialogueCanvas;

    //Scene One
    public Scene1Friend toEndConvo;

    // Scene Two
    public GulliverSelfDialogue scene2End;

    private Queue<string> sentences;

    Scene currentScene;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        Scene currentScene = SceneManager.GetActiveScene();

        sceneName = currentScene.name;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of convo");
        Time.timeScale = 1f;
        dialogueCanvasDisappear();

        //for Scene One
        if (sceneName == "Scene1")
        {
            toEndConvo.openingTalkDone = true;
        }

        //for Scene Two
        if (sceneName == "Scene2")
        {
            scene2End.openingTalkDoneS2 = true;
        }
    }

    public void dialogueCanvasAppear()
    {
        dialogueCanvas.SetActive(true);
    }

    public void dialogueCanvasDisappear()
    {
        dialogueCanvas.SetActive(false);
    }
}
