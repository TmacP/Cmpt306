using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button ammoButton;
    public Button damageButton;
    public Button heartButton;
    public Button skinButton;
    public Button skin1Button;
    public Button skin2Button;
    public Button skin3Button;
    public Button skin4Button;
    public Button skin5Button;
    public GameObject pauseScreen;
    public GameObject skinselectmenu;
    private bool enableDebugLogs = false; // Control debug logs

    void Start()
    {
        // Assuming skinButton is properly assigned in the Unity Editor
        ammoButton.onClick.AddListener(OnClickAmmo);
        damageButton.onClick.AddListener(OnClickDamage);
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
    if (Input.GetKeyDown(KeyCode.Escape) & !skinselectmenu.activeSelf) // Check if the Escape key is pressed
    {
        // Unpause
        if (enableDebugLogs) Debug.Log("unpause: "); // DEBUG
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
    }
}


    // Assume you have a collider on the shop GameObject with "Shop" tag
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        if (enableDebugLogs) Debug.Log("pause: "); // DEBUG
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        }
    }

    public void OnClickAmmo()
    {
        GameManager gameManager = GameManager.instance;
        if (GameManager.instance.playerMoney >= 5)
        {
            gameManager.AddAmmo(10);  
            GameManager.instance.playerMoney -= 5;
            GameManager.instance.UpdateMoneyVisual();
        }
    }


    public void OnClickDamage()
    {
        PlayerShoot playerShoot = FindObjectOfType<PlayerShoot>(); // Assuming only one PlayerShoot script in the scene

        if (GameManager.instance.playerMoney >= 10 && playerShoot != null)
        {
            // Get the current damage
            float currentDamage = playerShoot.GetProjectileDamage();

            // Increase the damage by 2
            float newDamage = currentDamage + 10;

            // Set the new damage
            playerShoot.SetProjectileDamage(newDamage);

            // Deduct money and update the visual
            GameManager.instance.playerMoney -= 10;
            GameManager.instance.UpdateMoneyVisual();

            if (enableDebugLogs) Debug.Log("Buy damage. New damage: " + newDamage); // DEBUG
        }
    }


    /// <summary> 
    /// Button to add additional hearts to player
    /// </summary>
    public void OnClickHeart()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        if (GameManager.instance.playerMoney >= 20 && healthBar.SpawnHearts < 10 )
        {
            GameManager.instance.playerMoney -= 20;
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
        int skinID = 1; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 5 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 5;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_1
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_1;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

    public void OnClickSkin1()
    {
        int skinID = 2; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 10 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 10;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_2;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

    public void OnClickSkin2()
    {
        int skinID = 3; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 15 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 15;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_3;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

    public void OnClickSkin3()
    {
        int skinID = 4; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 25 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 25;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_4;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

    public void OnClickSkin4()
    {
        int skinID = 5; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 50 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 50;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_5;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }

    public void OnClickSkin5()
    {
        int skinID = 6; // Assign a unique ID to each skin

        if (GameManager.instance.playerMoney >= 100 && !GameManager.instance.IsSkinPurchased(skinID))
        {
            GameManager.instance.playerMoney -= 100;
            GameManager.instance.UpdateMoneyVisual();
            
            // Update the player's sprite to rewardSprite_2
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.normalSprite = playerHealth.rewardSprite_6;
            }

            GameManager.instance.MarkSkinAsPurchased(skinID);

            if (enableDebugLogs) Debug.Log("buy a skin."); // DEBUG
        }
    }






}
