using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;

    public GameObject player;
  

    // Score Variables
    public Text scoreVisual;
    private int playerScore = 0;

    void Awake()
    {
        // I think this is for the player, change accordingly
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        UpdateScoreVisual();
    }
    // Update the Score Text Object
    void UpdateScoreVisual()
    {
        scoreVisual.text = "Score: " + playerScore.ToString();
    }
    // Award n amount of points (pointsAwarded depends on fish type etc.)
    public void AddScore(int pointsAwarded)
    {
        playerScore += pointsAwarded;
        Debug.Log(playerScore);
        UpdateScoreVisual();
    }

    public Vector3 GetPlayerPosition()
    {
        return player.transform.position;
    }


}
