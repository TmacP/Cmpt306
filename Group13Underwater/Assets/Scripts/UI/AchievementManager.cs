using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    public GameObject badgeObject1;
    public GameObject badgeObject2;
    public GameObject badgeObject3;
    public GameObject badgeObject4;
    public GameObject badgeObject5;
    public GameObject badgeObject6;
    public GameObject badgeObject7;
    public GameObject badgeObject8;
    public GameObject badgeObject9;

    public float displayTime = 3f;

    // HashSet to keep track of unlocked achievements
    private HashSet<string> unlockedAchievements = new HashSet<string>();

    void Start()
    {
        // Hide all badges at the start
        HideAllBadges();
    }

    public void ShowBadge(string achievementText, int badgeNumber)
    {
        // Check if the achievement has already been unlocked
        if (unlockedAchievements.Contains(achievementText))
        {
            // Achievement already unlocked, don't show the badge again
            return;
        }

        // Hide all badges first
        HideAllBadges();

        // Select the appropriate badge based on the badgeNumber
        GameObject selectedBadge = null;
        switch (badgeNumber)
        {
            case 1:
                selectedBadge = badgeObject1;
                break;
            case 2:
                selectedBadge = badgeObject2;
                break;
            case 3:
                selectedBadge = badgeObject3;
                break;
            case 4:
                selectedBadge = badgeObject4;
                break;
            case 5:
                selectedBadge = badgeObject5;
                break;
            case 6:
                selectedBadge = badgeObject6;
                break;
            case 7:
                selectedBadge = badgeObject7;
                break;
            case 8:
                selectedBadge = badgeObject8;
                break;
            case 9:
                selectedBadge = badgeObject9;
                break;

            default:
                Debug.LogWarning("Unknown badge number: " + badgeNumber);
                return;
        }

        // Set the text of the selected badge
        selectedBadge.GetComponentInChildren<Text>().text = achievementText;

        // Show the selected badge
        selectedBadge.SetActive(true);

        // Mark the achievement as unlocked
        unlockedAchievements.Add(achievementText);

        // Invoke the HideBadge method after the specified display time
        Invoke("HideAllBadges", displayTime);
    }

    void HideAllBadges()
    {
        // Hide all badges
        badgeObject1.SetActive(false);
        badgeObject2.SetActive(false);
        badgeObject3.SetActive(false);
        badgeObject4.SetActive(false);
        badgeObject5.SetActive(false);
        badgeObject6.SetActive(false);
        badgeObject7.SetActive(false);
        badgeObject8.SetActive(false);
        badgeObject9.SetActive(false);
    }
}
