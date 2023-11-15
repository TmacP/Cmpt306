using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts; // Assign the heart objects in the Inspector.
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    //public MoveSpeedBuff msBuff;


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
            //Debug.Log(playerMovement.gameObject.name);
            if (playerMovement != null)
            {
                Debug.Log("NOT NULL"); // This is NOT appearing. Trying to work in PlayerHealth script now
                //playerMovement.moveSpeed *= 0.5f; // Boost speed
                //powerupEffect.Apply(msBuff);
                //msBuff.Apply(playerObject);
            }
        }
        
    }
}
