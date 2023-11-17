using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This is a shop where a player can spend money to buy upgrades.
/// </summary>
/// <remarks>
/// can buy upgrades to increase the player's damage and movement speed
/// can buy upgrades to increase amounts of heart pieces / health
/// can buy cosmetic skins for the player
/// </remarks>
public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ShopScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Pause the game when the escape key is pressed, unpause when pressed again
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                // Unpause
                Time.timeScale = 1;
                ShopScreen.SetActive(false);
            }
            else
            {
                // Pause
                Time.timeScale = 0;
                ShopScreen.SetActive(true);
            }
        }

    }
}
