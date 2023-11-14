using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script attached to the player.
    private bool enableDebugLogs = true; // Flag to enable or disable debug logs.
    
    private bool isInvulnerable = false; // Flag to track player's invulnerability status.
    [SerializeField] private float invulnerabilityDuration = 2.0f; // Duration of invulnerability in seconds.

    // Initial player health value
    [SerializeField] public float playerHealth = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        // You can set up any initial configurations here.
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is currently invulnerable
        if (isInvulnerable)
        {
            // Implement logic for invulnerability, such as visual feedback.
            // For example, you might want to change the player's color or add a visual effect.
        }

        // Update the health display in the HealthBar script.
        healthBar.SetHealth(playerHealth / 100.0f);
    }

    // Function to modify the player's health and update the health display
    public void TakeDamage(float damage)
    {
        // Check if the player is currently invulnerable
        if (!isInvulnerable)
        {
            playerHealth -= damage;
            if (enableDebugLogs) { Debug.Log("Player took damage. Player health is: " + playerHealth); }

            if (playerHealth <= 0)
            {
                Destroy(this.gameObject);
                GameManager.instance.ReloadGameScene();
            }

            // Update the health display in the HealthBar script.
            healthBar.SetHealth(playerHealth / 100.0f);

            // Set the invulnerability flag to true and start the countdown
            StartCoroutine(StartInvulnerability());
        }
    }

    // Coroutine to handle the invulnerability timer
    IEnumerator StartInvulnerability()
    {
        isInvulnerable = true;

        // Wait for the specified duration
        yield return new WaitForSeconds(invulnerabilityDuration);

        // Reset the invulnerability flag
        isInvulnerable = false;
    }
}
