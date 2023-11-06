using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    public static GameManager instance = null;

    public GameObject player;

    // Score Variables
    public Text scoreVisual;
    private int playerScore = 0;

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
        UpdateScoreVisual();
        if (enableDebugLogs) Debug.Log("GameManager Start"); //DEBUG
    }

    void UpdateScoreVisual()
    {
        scoreVisual.text = "Score: " + playerScore.ToString();
        if (enableDebugLogs) Debug.Log("Updating Score Visual;"); //DEBUG
    }

    public void AddScore(int pointsAwarded)
    {
        playerScore += pointsAwarded;
        if (enableDebugLogs) Debug.Log("AddScore(), Points awarded to player; playerScore: " + playerScore); //DEBUG
        UpdateScoreVisual();
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }

    public void ReloadGameScene()
    {
        if (enableDebugLogs) Debug.Log("ReloadGameScene;"); //DEBUG
        playerScore = 0;
        UpdateScoreVisual();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
