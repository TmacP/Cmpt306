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
        moneyVisual.text = "Money: " + playerMoney.ToString();
        if (enableDebugLogs) Debug.Log("Updating Money Visual;"); //DEBUG
    }

    public void AddScore(int pointsAwarded)
    {
        playerScore += pointsAwarded;
        if (enableDebugLogs) Debug.Log("AddScore(), Points awarded to player; playerScore: " + playerScore); //DEBUG
        UpdateScoreVisual();


        // Check for achievements based on playerScore
        if (playerScore >= 1)
        {
            achievementManager.ShowBadge("Fantastic, You scored 1 point!", 1); // show badge 1
        }
        if (playerScore >= 5)
        {
            achievementManager.ShowBadge("Fantastic, You scored 5 point!", 2); // show badge 1
        }
        if (playerScore >= 10)
        {
            achievementManager.ShowBadge("Fantastic, You scored 10 point!", 3); // show badge 1
        }
        if (playerScore >= 20)
        {
            achievementManager.ShowBadge("Fantastic, You scored 20 point!", 4); // show badge 1
        }
        if (playerScore >= 30)
        {
            achievementManager.ShowBadge("Fantastic, You scored 30 point!", 5); // show badge 1
        }
        if (playerScore >= 40)
        {
            achievementManager.ShowBadge("Fantastic, You scored 40 point!", 6); // show badge 1
        }
        if (playerScore >= 50)
        {
            achievementManager.ShowBadge("Fantastic, You scored 50 point!", 7); // show badge 1
        }
        if (playerScore >= 60)
        {
            achievementManager.ShowBadge("Fantastic, You scored 60 point!", 8); // show badge 1
        }
        if (playerScore >= 70)
        {
            achievementManager.ShowBadge("Fantastic, You scored 70 point!", 9); // show badge 1
        }
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
