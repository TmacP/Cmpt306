using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject creditsScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Function for when you click "credits" button
    public void openCredits()
    {
        creditsScreen.SetActive(true);
    }
    // Function for when you click "back" button in credits
    public void backButton()
    {
        creditsScreen.SetActive(false);
    }
}
