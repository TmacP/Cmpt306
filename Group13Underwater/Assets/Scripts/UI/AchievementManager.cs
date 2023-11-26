using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AchievementManager : MonoBehaviour
{
    // Score badges
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
    // Enemy killed badges
    public GameObject enemyBadge1;
    public GameObject enemyBadge2;
    public GameObject enemyBadge3;
    public GameObject enemyBadge4;
    public GameObject enemyBadge5;
    public GameObject enemyBadge6;
    public GameObject enemyBadge7;
    public GameObject enemyBadge8;
    public GameObject enemyBadge9;
    public GameObject enemyBadge10;
    public GameObject enemyBadge11;
    public GameObject enemyBadge12;
    // money badges
    public GameObject moneyBadge1;
    public GameObject moneyBadge2;
    public GameObject moneyBadge3;
    public GameObject moneyBadge4;
    public GameObject moneyBadge5;
    public GameObject moneyBadge6;
    public GameObject moneyBadge7;
    public GameObject moneyBadge8;
    public GameObject moneyBadge9;
    public GameObject moneyBadge10;
    public GameObject moneyBadge11;




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
            // Score badges
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
            // Enemy killed badges
            case 13:
                selectedBadge = enemyBadge1;
                break;
            case 14:
                selectedBadge = enemyBadge2;
                break;
            case 15:    
                selectedBadge = enemyBadge3;
                break;
            case 16:
                selectedBadge = enemyBadge4;
                break;
            case 17:    
                selectedBadge = enemyBadge5;
                break;
            case 18:    
                selectedBadge = enemyBadge6;
                break;
            case 19:    
                selectedBadge = enemyBadge7;
                break;
            case 20:
                selectedBadge = enemyBadge8;
                break;  
            case 21:
                selectedBadge = enemyBadge9;
                break;
            case 22:
                selectedBadge = enemyBadge10;
                break;
            case 23:
                selectedBadge = enemyBadge11;
                break;
            case 24:
                selectedBadge = enemyBadge12;
                break;
            // Money badges
            case 25:
                selectedBadge = moneyBadge1;
                break;
            case 26:
                selectedBadge = moneyBadge2;
                break;  
            case 27:
                selectedBadge = moneyBadge3;
                break;  
            case 28:    
                selectedBadge = moneyBadge4;
                break;
            case 29:    
                selectedBadge = moneyBadge5;
                break;
            case 30:
                selectedBadge = moneyBadge6;
                break;
            case 31:
                selectedBadge = moneyBadge7;
                break;
            case 32:
                selectedBadge = moneyBadge8;
                break;
            case 33:
                selectedBadge = moneyBadge9;
                break;           
            case 34:
                selectedBadge = moneyBadge10;
                break;            
            case 35:
                selectedBadge = moneyBadge11;
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
        // Score badges
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
        // Enemy killed badges
        enemyBadge1.SetActive(false);
        enemyBadge2.SetActive(false);
        enemyBadge3.SetActive(false);
        enemyBadge4.SetActive(false);
        enemyBadge5.SetActive(false);
        enemyBadge6.SetActive(false);
        enemyBadge7.SetActive(false);
        enemyBadge8.SetActive(false);
        enemyBadge9.SetActive(false);
        enemyBadge10.SetActive(false);
        enemyBadge11.SetActive(false);
        enemyBadge12.SetActive(false);
        // Money badges
        moneyBadge1.SetActive(false);
        moneyBadge2.SetActive(false);
        moneyBadge3.SetActive(false);
        moneyBadge4.SetActive(false);
        moneyBadge5.SetActive(false);
        moneyBadge6.SetActive(false);
        moneyBadge7.SetActive(false);
        moneyBadge8.SetActive(false);
        moneyBadge9.SetActive(false);
        moneyBadge10.SetActive(false);
        moneyBadge11.SetActive(false);
    }
}
