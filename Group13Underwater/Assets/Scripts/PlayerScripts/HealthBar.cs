using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts; // Assign the heart objects in the Inspector.
    public int spawnHearts = 5; // Number of hearts to spawn
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    // Start is called before the first frame update
    void Start()
    {
        // Initially hide hearts
        InitializeHearts(spawnHearts);
    }

    // Update the health display based on the provided health percentage.
    public void SetHealth(float healthPercentage)
    {
        int numHeartsToShow = Mathf.CeilToInt(healthPercentage * spawnHearts);

        for (int i = 0; i < spawnHearts; i++)
        {
            if (i < numHeartsToShow)
            {
                hearts[i].sprite = fullHeartSprite;
            }
            else
            {
                hearts[i].sprite = emptyHeartSprite;
            }
        }

        // Check if there is exactly 1 heart, then boost speed
        if (numHeartsToShow == 1)
        {
            // Access the PlayerMovement component and adjust the speed here
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.moveSpeed *= 0.5f; // Boost speed
            }
        }
    }

    // Initialize the hearts, enabling the specified number of hearts and disabling the rest.
    private void InitializeHearts(int visibleHearts)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < visibleHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
