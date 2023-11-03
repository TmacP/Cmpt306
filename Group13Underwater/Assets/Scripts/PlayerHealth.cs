using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script attached to the player.

    // Start is called before the first frame update
    void Start()
    {
        // You can set up any initial configurations here.
    }

    // Update is called once per frame
    void Update()
    {
        // You can add any health-related logic here.
    }

    // Function to modify the player's health and update the health display
    private void ModifyPlayerHealth(int healthChange)
    {
        // Calculate the new health percentage
        float newHealthPercentage = (healthBar.playerHealth + healthChange) / 100.0f;

        // Call the SetHealth function in the HealthBar script to update the health display
        healthBar.SetHealth(newHealthPercentage);
    }
}
