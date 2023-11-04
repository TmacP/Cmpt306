using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseScreen;
    void Start()
    {
        
    }

    // Update is called once per frame
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
}
