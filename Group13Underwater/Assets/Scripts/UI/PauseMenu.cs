using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button skinButton;
    public GameObject pauseScreen;
    private bool enableDebugLogs = true; // Control debug logs

    void Start()
    {
        // Assuming skinButton is properly assigned in the Unity Editor
        skinButton.onClick.AddListener(OnClickSkin);
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

    public void OnClickSkin()
    {
        if (GameManager.instance.playerMoney >= 1)
        {
            GameManager.instance.playerMoney -= 1;
            GameManager.instance.UpdateMoneyVisual();
            if (enableDebugLogs) Debug.Log("buy a skin."); //DEBUG
        }
    }
}
