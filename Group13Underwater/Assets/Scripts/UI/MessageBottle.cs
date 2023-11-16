using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageBottle : MonoBehaviour
{
 
    public GameObject messageScreen;
    public TextMeshProUGUI bottleMessage; // This is the message that appears in the scroll pop up
    string[] messages = new string[] { "To the one who finds this bottle, be shore of yourself! I put a few dollars in here to support your journey.", "May this message find its way to the one who needs it. Seas the day! Here’s five dollars from yours truly.", "Dear reader, you are doing fin-tastic! Buy yourself something nice with the money I left.", "May this bottle reach you at a time in need. Don’t be crabby, heres some money to bring your spirits up." };

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
        string RandomWord= messages[Random.Range(0, messages.Length)];
        bottleMessage.text = RandomWord;
    }
    
    // Button function for the user to close the screen
    public void CloseMessage()
    {
        // Set Active False?
        messageScreen.SetActive(false);
        Time.timeScale = 1;
    }


}
