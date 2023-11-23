using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
 
    public string StartScene;
    public string MainScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Function for retrying the game (all this does will be hide our screen and make time continue
    public void retryGame()
    {

        // Tells the scene manager to load our main scene
        SceneManager.LoadScene(MainScreen);
    }
    // Function for our exit button, this takes player to start screen
    // Note: for exit function we might need to change time time scale back also
    public void exitToStart()
    {

        // Tells the scene manager to load our start scene
        SceneManager.LoadScene(StartScene);
    }
}
