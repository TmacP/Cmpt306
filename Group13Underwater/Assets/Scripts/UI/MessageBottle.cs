using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBottle : MonoBehaviour
{

    public GameObject messageScreen;
    public GameObject playerPref;
    public TextMeshProUGUI bottleMessage; // This is the message that appears in the scroll pop up
    string[] messages = new string[] { "Be shore of yourself!", "Seas the day!", "You are doing fin-tastic!", "Don’t be crabby!", "Treat yourshellf!", "Seas and greetings!", "Water you waiting for?", "Good things come to those who bait." };

    // Start is called before the first frame update
    void Start()
    {
        // this should change the text of the message
        messagePicker();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // Randomly pick a message from an array
    public void messagePicker()
    {
        // pick one of the messages
        string RandomWord = messages[Random.Range(0, messages.Length)];
        bottleMessage.text = RandomWord;
    }

    // Button function for the user to close the screen
    public void CloseMessage()
    {
        // Set Active False?
        messageScreen.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && (GameManager.instance != null))
        {
            // Add 5 money
            //GameManager.instance.AddMoney(5);
            // Destroy the bottle 
            //Destroy(other.gameObject);

            // Show the message (pause game, show message panel)
            Time.timeScale = 0;
            messageScreen.SetActive(true);

            

        }


    }
}
