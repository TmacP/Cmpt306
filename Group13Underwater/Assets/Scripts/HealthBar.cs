using UnityEngine;
using UnityEngine.UI;

// The HealthBar script is responsible for displaying the player's health using heart icons.
// It receives the health percentage from the HealthManager and updates the heart icons accordingly.
public class HealthBar : MonoBehaviour
{
    // Reference to the heart icon prefab that will be displayed in the health bar.
    public GameObject heartPrefab;

    // Parent transform where the heart icons will be instantiated.
    public Transform heartsParent;

    // Define the maximum number of hearts in the health bar.
    public int maxHearts = 5; // Adjust this number as needed.

    // Initializes the HealthBar.
    private void Start()
    {
        // You can set up any initial configurations here.
    }

    // Sets the health bar display based on the provided health percentage.
    // It calculates the number of heart icons to display based on the health percentage.
    // Clears existing heart icons and instantiates new ones accordingly.
    public void SetHealth(float healthPercentage)
    {
        int totalHearts = Mathf.CeilToInt(healthPercentage * maxHearts);

        // Clear the existing hearts.
        foreach (Transform child in heartsParent)
        {
            Destroy(child.gameObject);
        }

        // Instantiate heart icons based on health percentage.
        for (int i = 0; i < maxHearts; i++)
        {
            GameObject heart = Instantiate(heartPrefab, heartsParent);

            // Set the state of the heart (full/empty) based on the current health.
            if (i < totalHearts)
            {
                // Set it as a full heart.
                // You may need to handle your heart visuals here.
            }
            else
            {
                // Set it as an empty heart.
                // You may need to handle your heart visuals here.
            }
        }
    }
}
