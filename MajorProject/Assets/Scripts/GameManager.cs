using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int seedAmount;
    public static GameObject[] seedsToPickUp;
    public Text seedAmountText;
    public static int playerHealth = 100;
    public Text playerHealthText;

    // Start is called before the first frame update
    void Start()
    {
        seedsToPickUp = GameObject.FindGameObjectsWithTag("pickUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (seedAmount == 1)
            seedAmountText.text = seedAmount + " Seed";
        else if (seedAmount > 1)
            seedAmountText.text = seedAmount + " Seeds";
        else
            seedAmountText.text = "No Seeds!";

        if (playerHealth > 0)
            playerHealthText.text = playerHealth + " health";
    }
}
