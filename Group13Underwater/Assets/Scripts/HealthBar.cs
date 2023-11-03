using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartsParent;
    public int maxHearts = 5; // Adjust this number as needed.

    // Reference to the player's health (make it public for accessibility).
    public float playerHealth = 100.0f; // You can set the initial health value.

    // Reference to full and empty heart sprites.
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    private void Start()
    {
        // Initialize the health bar when the game starts.
        InitializeHealthBar();
    }

    private void InitializeHealthBar()
    {
        // Clear the existing hearts.
        foreach (Transform child in heartsParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate heart icons based on the maximum number of hearts.
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsParent);
            Image heartImage = heart.GetComponent<Image>(); // Access the Image component

            // Set the sprite of the heart (full/empty) based on the current health.
            if (i < Mathf.CeilToInt(playerHealth / (100.0f / maxHearts)))
            {
                heartImage.sprite = fullHeartSprite;
            }
            else
            {
                heartImage.sprite = emptyHeartSprite;
            }
        }
    }

    // Update the health display based on the provided health percentage.
    public void SetHealth(float healthPercentage)
    {
        playerHealth = Mathf.Clamp(healthPercentage * 100.0f, 0.0f, 100.0f);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        for (int i = 0; i < maxHearts; i++)
        {
            Transform heart = heartsParent.GetChild(i);
            Image heartImage = heart.GetComponent<Image>(); // Access the Image component

            // Set the sprite of the heart (full/empty) based on the current health.
            if (i < Mathf.CeilToInt(playerHealth / (100.0f / maxHearts)))
            {
                heartImage.sprite = fullHeartSprite;
            }
            else
            {
                heartImage.sprite = emptyHeartSprite;
            }
        }
    }
}
