using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    public GameObject scoreBadge1;
    public GameObject scoreBadge2;
    public GameObject scoreBadge3;
    public GameObject scoreBadge4;
    public GameObject scoreBadge5;
    public GameObject scoreBadge6;
    public GameObject scoreBadge7;
    public GameObject scoreBadge8;
    public GameObject scoreBadge9;
    public GameObject scoreBadge10;
    public GameObject scoreBadge11;
    public GameObject scoreBadge12;



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
                selectedBadge = scoreBadge1;
                break;
            case 2:
                selectedBadge = scoreBadge2;
                break;
            case 3:
                selectedBadge = scoreBadge3;
                break;
            case 4:
                selectedBadge = scoreBadge4;
                break;
            case 5:
                selectedBadge = scoreBadge5;
                break;
            case 6:
                selectedBadge = scoreBadge6;
                break;
            case 7:
                selectedBadge = scoreBadge7;
                break;
            case 8:
                selectedBadge = scoreBadge8;
                break;
            case 9:
                selectedBadge = scoreBadge9;
                break;
            case 10:
                selectedBadge = scoreBadge10;
                break;  
            case 11:    
                selectedBadge = scoreBadge11;
                break;
            case 12:    
                selectedBadge = scoreBadge12;
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
        scoreBadge1.SetActive(false);
        scoreBadge2.SetActive(false);
        scoreBadge3.SetActive(false);
        scoreBadge4.SetActive(false);
        scoreBadge5.SetActive(false);
        scoreBadge6.SetActive(false);
        scoreBadge7.SetActive(false);
        scoreBadge8.SetActive(false);
        scoreBadge9.SetActive(false);
        scoreBadge10.SetActive(false);
        scoreBadge11.SetActive(false);
        scoreBadge12.SetActive(false);
    }
}
