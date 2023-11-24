using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinSelectMenu : MonoBehaviour
{
    public GameObject skinselectmenu;
    public Button skinSwitchButton;
    public Button skin1SwitchButton;
    public Button skin2SwitchButton;
    public Button skin3SwitchButton;
    public Button skin4SwitchButton;
    public Button skin5SwitchButton;

    void Start()
    {
        skinSwitchButton.onClick.AddListener(OnClickSkin);
        skin1SwitchButton.onClick.AddListener(OnClickSkin1);
        skin2SwitchButton.onClick.AddListener(OnClickSkin2);
        skin3SwitchButton.onClick.AddListener(OnClickSkin3);
        skin4SwitchButton.onClick.AddListener(OnClickSkin4);
        skin5SwitchButton.onClick.AddListener(OnClickSkin5);
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
                skinselectmenu.SetActive(false);
            }
            else
            {
                // Pause
                Time.timeScale = 0;
                skinselectmenu.SetActive(true);
            }
        }
    }

    void OnClickSkin()
    {
        TrySwitchSkin(1); // Assuming 0 corresponds to the default skin
    }

    void OnClickSkin1()
    {
        TrySwitchSkin(2);
    }

    void OnClickSkin2()
    {
        TrySwitchSkin(3);
    }

    void OnClickSkin3()
    {
        TrySwitchSkin(4);
    }

    void OnClickSkin4()
    {
        TrySwitchSkin(5);
    }

    void OnClickSkin5()
    {
        TrySwitchSkin(6);
    }

    void TrySwitchSkin(int skinID)
    {
        if (GameManager.instance.IsSkinPurchased(skinID))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                // Assuming rewardSprite_0 corresponds to the default sprite
                playerHealth.normalSprite = playerHealth.GetRewardSpriteByID(skinID);

            }
        }
    }
}
