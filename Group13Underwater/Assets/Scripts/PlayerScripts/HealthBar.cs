using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts; // Assign the heart objects in the Inspector.
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;



    public update()
    {
       if (numHeartsToShow > 1)
        {
            // Access the PlayerMovement component and adjust the speed here
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.moveSpeed = 1000; // Boost speed
            }
        }
    }

    // Update the health display based on the provided health percentage.
    public void SetHealth(float healthPercentage)
    {
        int numHeartsToShow = Mathf.CeilToInt(healthPercentage * hearts.Length);

        for (int i = 0; i < hearts.Length; i++)
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
                playerMovement.moveSpeed *= 0.5f; // Boost speed // is undone in HealBuff.cs via magic numer!!!
            }
        }
        
    }
}
