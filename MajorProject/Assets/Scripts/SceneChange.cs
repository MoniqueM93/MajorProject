using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject leaveCanvas;
    public GameObject leaveArea;

    //For Scene 1
    public Scene1Friend talkRefS1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (talkRefS1.S1AllTalkDone == true)
        {
            leaveArea.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == leaveArea)
        {
            leaveCanvas.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == leaveArea)
        {
            if (Input.GetKey(KeyCode.W))
            {
                SceneManager.LoadScene("Scene2");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == leaveArea)
        {
            leaveCanvas.SetActive(false);
        }
    }
}
