using UnityEngine;

// The HealthManager script manages the player's health and updates the HealthBar.
// It handles health calculations, damage-taking, and updates the health bar display.
public class HealthManager : MonoBehaviour
{
    // The maximum health of the player.
    public float maxHealth = 100.0f;

    // The current health of the player.
    public float health = 100.0f;

    // Reference to the HealthBar component for updating the health bar display.
    public HealthBar healthBar;

    // Update is called once per frame, and can be used for game logic.
    void Update()
    {
        // Implement any other game logic here.
    }

    // Inflict damage to the player and update the health bar display.
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Handle player death here.
        }

        UpdateHealthBar();
    }

    // Update the health bar's display based on the current health value.
    private void UpdateHealthBar()
    {
        // Calculate the health percentage.
        float healthPercentage = Mathf.Clamp01(health / maxHealth);

        // Update the health bar's display.
        healthBar.SetHealth(healthPercentage);
    }
}
