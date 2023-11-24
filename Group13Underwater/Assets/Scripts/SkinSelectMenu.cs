using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkinSelectMenu : MonoBehaviour
{
    void Update()
    {
        // Pause the game when the escape key is pressed, unpause when pressed again
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                // Unpause
                Time.timeScale = 1;
                gameObject.SetActive(false);
            }
            else
            {
                // Pause
                Time.timeScale = 0;
                gameObject.SetActive(true);
            }
        }
    }
}
