using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public GameObject badgeObject;
    public float displayTime = 3f;

    void Start()
    {
        // Hide the badge at the start
        HideBadge();
    }

    public void ShowBadge(string achievementText)
    {
        // Set the text of the badge
        badgeObject.GetComponentInChildren<Text>().text = achievementText;

        // Show the badge
        badgeObject.SetActive(true);

        // Invoke the HideBadge method after the specified display time
        Invoke("HideBadge", displayTime);
    }

    void HideBadge()
    {
        // Hide the badge
        badgeObject.SetActive(false);
    }
}
