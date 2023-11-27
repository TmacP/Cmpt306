using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public string MainGameScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // When the player presses start, we move into the main scene using scene manager
    public void StartGame()
    {
        // Tells the scene manager to load our main scene
        SceneManager.LoadScene(MainGameScene);
    }
    // This will let the user exit the game and go back to their desktop etc
    public void ExitGame()
    {
        Application.Quit();
    }


}
