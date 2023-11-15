using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthBar; // Reference to the HealthBar script attached to the player.
    private bool enableDebugLogs = true; // Flag to enable or disable debug logs.
    private PlayerMovement player;
    private bool isInvulnerable = false; // Flag to track player's invulnerability status.
    [SerializeField] private float invulnerabilityDuration = 2.0f; // Duration of invulnerability in seconds.

    [SerializeField] private Sprite normalSprite; // The normal sprite of the player
    [SerializeField] private Sprite invulnerableSprite; // The sprite to use during invulnerability

    // Initial player health value
    [SerializeField] public float playerHealth = 100.0f;

    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component

    [SerializeField] private MoveSpeedBuff msBuff;

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to the player GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerMovement>();
        // You can set up any initial configurations here.
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is currently invulnerable
        if (isInvulnerable)
        {
            // Change the player's sprite to the invulnerable sprite
            spriteRenderer.sprite = invulnerableSprite;

            // Implement any other logic for invulnerability, such as additional visual feedback.
            // For example, you might want to change the player's color or add a visual effect.
        }
        else
        {
            // Change the player's sprite back to the normal sprite
            spriteRenderer.sprite = normalSprite;
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

            // Check if player's health is down to 20
            if (playerHealth <= 20)
            {
                //player.moveSpeed *= 2.0f;
                Debug.Log(player);
                msBuff.Apply(player.gameObject);
                // Implement code when player's health is down to 20
                // For example, you can play a warning sound or trigger a visual effect.
                // Add your specific code here.
                if (enableDebugLogs) { Debug.Log("Player's health is down to 20!"); }
            }
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
