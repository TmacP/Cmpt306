using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script attached to the player.
    private bool enableDebugLogs = true; // Flag to enable or disable debug logs.

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
        // Update the health display in the HealthBar script.
        healthBar.SetHealth(playerHealth / 100.0f);
    }

        // Function to modify the player's health and update the health display
    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        if (enableDebugLogs){Debug.Log("Player took damage. Playerhealth is: " + playerHealth);}
 

        if (playerHealth <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.ReloadGameScene();
        }

        // Update the health display in the HealthBar script.
        healthBar.SetHealth(playerHealth / 100.0f);
    }

}
