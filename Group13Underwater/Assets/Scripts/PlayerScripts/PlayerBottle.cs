using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBottle : MonoBehaviour
{
    //public GameObject messageScreen;
    public GameObject bottle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "MessageBottle" && (GameManager.instance != null))
        {
            // Add 5 money
            GameManager.instance.AddMoney(5);
            // Destroy the bottle 
            Destroy(other.gameObject);

            // Show the message (pause game, show message panel)
            Time.timeScale = 0;
           // messageScreen.SetActive(true);

            // Close message with button in message bottle script

        }
    }
}
