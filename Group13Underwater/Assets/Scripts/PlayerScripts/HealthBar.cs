using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts; // Assign the heart objects in the Inspector.
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

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
    }
}
