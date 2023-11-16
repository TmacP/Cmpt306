using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button heartButton;
    public Button skinButton;
    public Button skin1Button;
    public Button skin2Button;
    public Button skin3Button;
    public Button skin4Button;
    public Button skin5Button;
    public GameObject pauseScreen;
    private bool enableDebugLogs = true; // Control debug logs

    void Start()
    {
        // Assuming skinButton is properly assigned in the Unity Editor
        heartButton.onClick.AddListener(OnClickHeart);
        skinButton.onClick.AddListener(OnClickSkin);
        skin1Button.onClick.AddListener(OnClickSkin1);
        skin2Button.onClick.AddListener(OnClickSkin2);
        skin3Button.onClick.AddListener(OnClickSkin3);
        skin4Button.onClick.AddListener(OnClickSkin4);
        skin5Button.onClick.AddListener(OnClickSkin5);

    }

    void Update()
    {
        // Pause the game when the escape key is pressed, unpause when pressed again
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                // Unpause
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
            }
            else
            {
                // Pause
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
            }
        }
    }

    /// <summary> 
    /// Button to add additional hearts to player
    /// </summary>
    public void OnClickHeart()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        if (GameManager.instance.playerMoney >= 100 && healthBar.SpawnHearts < 10 )
        {
            GameManager.instance.playerMoney -= 100;
            GameManager.instance.UpdateMoneyVisual();

            if (playerHealth != null && healthBar != null)
            {
                healthBar.SpawnHearts += 1;
                playerHealth.playerHealth += 10;
                playerHealth.fullHealth += 10;   
                if (enableDebugLogs) Debug.Log("buy a heart."); // DEBUG
            }
            else
            {
                if (enableDebugLogs) Debug.Log("playerHealth or healthBar is null."); // DEBUG
            }

        }
    }
    



    /// <summary>
    /// Here is the skins for sale. the code is copy pasted which should be genralized. but I think we can accept ugly code since it isn't going to live past this month.
    /// </summary>
    public void OnClickSkin()
    {
        if (GameManager.instance.playerMoney >= 20)
        {
            GameManager.instance.playerMoney -= 20;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_1
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_1;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }


    public void OnClickSkin1()
    {
        if (GameManager.instance.playerMoney >= 20)
        {
            GameManager.instance.playerMoney -= 20;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_2;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

        public void OnClickSkin2()
    {
        if (GameManager.instance.playerMoney >= 20)
        {
            GameManager.instance.playerMoney -= 20;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_3
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_3;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

        public void OnClickSkin3()
    {
        if (GameManager.instance.playerMoney >= 50)
        {
            GameManager.instance.playerMoney -= 50;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_4
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_4;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }


        public void OnClickSkin4()
    {
        if (GameManager.instance.playerMoney >= 100)
        {
            GameManager.instance.playerMoney -= 100;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_5
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_5;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

            public void OnClickSkin5()
    {
        if (GameManager.instance.playerMoney >= 200)
        {
            GameManager.instance.playerMoney -= 200;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_6
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_6;
            }

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

}
