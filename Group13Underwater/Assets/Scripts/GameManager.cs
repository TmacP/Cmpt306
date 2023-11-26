using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class GameManager : MonoBehaviour
    {

    // Define the achievements and their corresponding messages and badge numbers
    string[] messages = {
        "Nice, scored {0} point!",
        "Great, scored {0} points!",
        "Excellent, scored {0} points!",
        "Amazing, scored {0} points!",
        "Awesome, scored {0} points!",
        "Exciting, scored {0} points!",
        "Incredible, scored {0} points!",
        "Unbelievable, scored {0} points!",
        "Outstanding, scored {0} points!",
        "Otherworldly, scored {0} points!",
        "Superhuman, scored {0} points!",
        "Fantastic, scored {0} points!"
    };
        string[] enemyMessages = {
        "Skilled! Defeated {0} enemies!",
        "Mighty! Triumphed over {0} foes!",
        "Warrior! Conquered {0} enemies!",
        "Heroic! Against {0} adversaries!",
        "Formidable! Against {0} opponents!",
        "Valiant! Victory against {0} enemies!",
        "Unyielding! Overcame {0} adversaries!",
        "Invincible! Defeated {0} enemies!",
        "Supreme! Vanquished {0} foes!",
        "Legendary! Against {0} adversaries!",
        "Warlord! Conquered {0} enemies!",
        "Epic! Triumphant against {0} foes!"
    };

    string[] moneyMessages = {
        "Thrifty! Collected {0} money!",
        "Prosperous! Collected {0} money!",
        "Wealthy! Collected {0} money!",
        "Opulent! Collected {0} money!",
        "Affluent! Collected {0} money!",
        "Grandiose! Collected {0} money!",
        "Sumptuous! Collected {0} money!",
        "Extravagant! Collected {0} money!",
        "Majestic! Collected {0} money!",
        "Affluence! Collected {0} money!",
        "Fortunate! Collected {0} money!",
        "Bountiful! Collected {0} money!"
    };


    int[] badgeNumbersScore = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

    int[] badgeNumbersEnemy = { 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};

    int[] badgeNumbersMoney = { 25, 26, 27, 28, 29, 30, 31, 32, 33, 33, 34, 35 };
    
    private int nextScoreAward = 10;
    private int nextEnemyKilledAward = 10;
    private int nextMoneyAward = 10;

    public AchievementManager achievementManager;
    private bool enableDebugLogs = false; // Control debug logs
    public static GameManager instance = null;

    public GameObject player;

    public MoveSpeedBuff msBuff;
    public MagnetismBuff magnetismBuff;

    // Sound Variables
    public AudioSource moneySound; // Assign in Unity Editor
    public AudioSource scoreSound; // Assign in Unity Editor

    // Score Variables
    public Text scoreVisual;
    public Text moneyVisual;
    private int playerScore = 0; 
    public int playerMoney = 0;
    public int totalMoney = 0;
    public int enemyKilled = 0; // Used for achievements

    private List<int> purchasedSkins = new List<int>(); // List to store purchased skin IDs

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


    public bool IsSkinPurchased(int skinID)
    {
        return purchasedSkins.Contains(skinID);
    }

    public void MarkSkinAsPurchased(int skinID)
    {
        if (!purchasedSkins.Contains(skinID))
        {
            purchasedSkins.Add(skinID);
        }
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
    scoreSound.Play();

    // Check if the score is in the range for the next badge
    if (playerScore >= nextScoreAward && playerScore < nextScoreAward + 10)
    {
        // Pick a random index for the message and badgeNumber
        int randomIndex = Random.Range(0, messages.Length);
        string message = string.Format(messages[randomIndex], nextScoreAward);
        int badgeNumber = badgeNumbersScore[randomIndex];

        achievementManager.ShowBadge(message, badgeNumber);

        // Increment nextScoreAward by 10
        nextScoreAward += 10;
        }
    }



    public void AddEnemyKilled(int enemiesKilled)
    {
        enemyKilled += enemiesKilled;
        if (enableDebugLogs) Debug.Log("AddEnemyKilled(), Enemies killed; enemyKilled: " + enemyKilled); //DEBUG

        // Check if the enemyKilled is in the range for the next badge
        if (enemyKilled >= nextEnemyKilledAward && enemyKilled < nextEnemyKilledAward + 10)
        {
            // Pick a random index for the message and badgeNumber
            int randomIndex = Random.Range(0, enemyMessages.Length);
            string message = string.Format(enemyMessages[randomIndex], nextEnemyKilledAward);
            int badgeNumber = badgeNumbersEnemy[randomIndex];

            achievementManager.ShowBadge(message, badgeNumber);

            // Increment nextEnemyKilledAward by 10
            nextEnemyKilledAward += 10;

            // If nextEnemyKilledAward exceeds the maximum, wrap around to the beginning
            if (nextEnemyKilledAward >= enemyMessages.Length * 10)
            {
                nextEnemyKilledAward = 10;
            }
        }
    }

    public void AddMoney(int moneyAwarded)
    {
        playerMoney += moneyAwarded;
        totalMoney += moneyAwarded; // Used for achievements
        if (enableDebugLogs) Debug.Log("AddMoney(), Money awarded to player; playerMoney: " + playerMoney); //DEBUG
        UpdateMoneyVisual();
        // sound
        moneySound.Play();

        // Check if the money is in the range for the next badge
        if (totalMoney >= nextMoneyAward && totalMoney < nextMoneyAward + 10)
        {
            // Pick a random index for the message and badgeNumber
            int randomIndex = Random.Range(0, moneyMessages.Length);
            string message = string.Format(moneyMessages[randomIndex], nextMoneyAward);
            int badgeNumber = badgeNumbersMoney[randomIndex];

            achievementManager.ShowBadge(message, badgeNumber);

            // Increment nextMoneyAward by 10
            nextMoneyAward += 10;
        }

    }

    public Vector3 GetPlayerPosition()
    {
        if (player != null)
        {
            return player.transform.position;
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }

    public void ReloadGameScene()
    {
        if (enableDebugLogs) Debug.Log("ReloadGameScene;"); //DEBUG
        playerScore = 0;
        playerMoney = 0;
        nextScoreAward = 10;
        nextEnemyKilledAward = 10;
        nextMoneyAward = 10;
        UpdateScoreVisual();
        UpdateMoneyVisual();
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    }
}
