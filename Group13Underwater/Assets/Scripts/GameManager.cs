using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public AchievementManager achievementManager;
    private bool enableDebugLogs = false; // Control debug logs
    public static GameManager instance = null;

    public GameObject player;

    public MoveSpeedBuff msBuff;
    public MagnetismBuff magnetismBuff;

    // Score Variables
    public Text scoreVisual;
    public Text moneyVisual;
    private int playerScore = 0; 
    public int playerMoney = 0;
    private int enemyKilled = 0; // Used for achievements

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        if (enableDebugLogs) Debug.Log("GameManager Awake"); //DEBUG
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScore = 0;
        playerMoney = 0;
        UpdateScoreVisual();
        UpdateMoneyVisual();
        msBuff.IsBuffedRestart();
        magnetismBuff.IsBuffedRestart();
        if (enableDebugLogs) Debug.Log("GameManager Start"); //DEBUG
    }

    void UpdateScoreVisual()
    {
        scoreVisual.text = "Score: " + playerScore.ToString();
        if (enableDebugLogs) Debug.Log("Updating Score Visual;"); //DEBUG
    }
    public void UpdateMoneyVisual()
    {
        moneyVisual.text = "Money: " + playerMoney.ToString() + " $";
        if (enableDebugLogs) Debug.Log("Updating Money Visual;"); //DEBUG
    }

    public void AddScore(int pointsAwarded)
    {
        playerScore += pointsAwarded;
        if (enableDebugLogs) Debug.Log("AddScore(), Points awarded to player; playerScore: " + playerScore); //DEBUG
        UpdateScoreVisual();


        // Check for achievements based on playerScore
        if (playerScore >= 1) achievementManager.ShowBadge("Nice, scored 1 point!", 1);
        if (playerScore >= 5) achievementManager.ShowBadge("Great, scored 5 points!", 2);
        if (playerScore >= 10) achievementManager.ShowBadge("Excellent, scored 10 points!", 3);
        if (playerScore >= 20) achievementManager.ShowBadge("Amazing, scored 20 points!", 4);
        if (playerScore >= 30) achievementManager.ShowBadge("Awesome, scored 30 points!", 5);
        if (playerScore >= 40) achievementManager.ShowBadge("Exciting, scored 40 points!", 6);
        if (playerScore >= 50) achievementManager.ShowBadge("Incredible, scored 50 points!", 7);
        if (playerScore >= 60) achievementManager.ShowBadge("Unbelievable, scored 60 points!", 8);
        if (playerScore >= 70) achievementManager.ShowBadge("Outstanding, scored 70 points!", 9);
        if (playerScore >= 80) achievementManager.ShowBadge("Otherworldly, scored 80 points!", 10);
        if (playerScore >= 90) achievementManager.ShowBadge("Superhuman, scored 90 points!", 11);
        if (playerScore >= 100) achievementManager.ShowBadge("Fantastic, scored 100 points!", 12);
    }

    public void AddEnemyKilled(int enemiesKilled)
    {
        enemyKilled += enemiesKilled;
        if (enableDebugLogs) Debug.Log("AddEnemyKilled(), Enemies killed; enemyKilled: " + enemyKilled); //DEBUG
        if (enemyKilled >= 1) achievementManager.ShowBadge("Nice, killed 1 enemy!", 13);
        if (enemyKilled >= 5) achievementManager.ShowBadge("Great, killed 5 enemies!", 14);
        if (enemyKilled >= 10) achievementManager.ShowBadge("Excellent, killed 10 enemies!", 15);
        if (enemyKilled >= 20) achievementManager.ShowBadge("Amazing, killed 20 enemies!", 16);
        if (enemyKilled >= 30) achievementManager.ShowBadge("Awesome, killed 30 enemies!", 17);
        if (enemyKilled >= 40) achievementManager.ShowBadge("Exciting, killed 40 enemies!", 18);
        if (enemyKilled >= 50) achievementManager.ShowBadge("Incredible, killed 50 enemies!", 19);
        if (enemyKilled >= 60) achievementManager.ShowBadge("Unbelievable, killed 60 enemies!", 20);
        if (enemiesKilled >= 70) achievementManager.ShowBadge("Outstanding, killed 70 enemies!", 21);
        if (enemiesKilled >= 80) achievementManager.ShowBadge("Otherworldly, killed 80 enemies!", 22);
        if (enemiesKilled >= 90) achievementManager.ShowBadge("Superhuman, killed 90 enemies!", 23);
        if (enemiesKilled >= 100) achievementManager.ShowBadge("Fantastic, killed 100 enemies!", 24);
    }

    public void AddMoney(int moneyAwarded)
    {
        playerMoney += moneyAwarded;
        if (enableDebugLogs) Debug.Log("AddMoney(), Money awarded to player; playerMoney: " + playerMoney); //DEBUG
        UpdateMoneyVisual();
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }

    public void ReloadGameScene()
    {
        if (enableDebugLogs) Debug.Log("ReloadGameScene;"); //DEBUG
        playerScore = 0;
        playerMoney = 0;
        UpdateScoreVisual();
        UpdateMoneyVisual();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
