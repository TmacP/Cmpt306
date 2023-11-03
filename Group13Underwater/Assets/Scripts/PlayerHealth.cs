using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script attached to the player.
    private bool enableDebugLogs = true; // Flag to enable or disable debug logs.

    // Initial player health value
    [SerializeField] private float playerHealth = 100.0f;

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
    public void TakeDamage(float damage)
    {
        if (enableDebugLogs){Debug.Log("Player took damage. Playerhealth is: " + playerHealth);}
        playerHealth -= damage;

        if (playerHealth <= 0)
        {
            // Handle player death or any other logic here.
        }

        // Update the health display in the HealthBar script.
        healthBar.SetHealth(playerHealth / 100.0f);
    }

}
