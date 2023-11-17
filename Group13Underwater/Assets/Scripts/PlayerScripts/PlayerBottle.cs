using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBottle : MonoBehaviour
{
    public GameObject messageScreen;
    public GameObject bottle;

    public TextMeshProUGUI bottleMessage; // This is the message that appears in the scroll pop up
    string[] messages = new string[] { "To the one who finds this bottle, be shore of yourself! I put a few dollars in here to support your journey.", "May this message find its way to the one who needs it. Seas the day! Here’s five dollars from yours truly.", "Dear reader, you are doing fin-tastic! Buy yourself something nice with the money I left.", "May this bottle reach you at a time in need. Don’t be crabby, heres some money to bring your spirits up.", "When you open this bottle, remember: You have got this far, keep going. Use the money I left you and treat yourshellf!", "Seas and greetings! Keep up the good work. Here is some money for your troubles.", "To the lucky one who find this, water you waiting for? Take this 5 dollars and swim!", "Dear finder of this bottle, good things come to those who bait. Take this money I left you, you deserve it!" };

    void Start()
    {
        // this should change the text of the message
        //messagePicker();
    }
    private void Update()
    {
       
    }

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
        if (other.transform.tag == "MessageBottle" && (GameManager.instance != null))
        {
            GameManager gameManager = GameManager.instance;

            // Each time a bottle is caught, we want a new message to be chosen
            messagePicker();
            // Add 5 money
            gameManager.AddMoney(5);
            // Destroy the bottle 
            Destroy(other.gameObject);

            // Show the message (pause game, show message panel)
            Time.timeScale = 0;
            messageScreen.SetActive(true);

            // Close message with button in message bottle script

        }
    }
}
