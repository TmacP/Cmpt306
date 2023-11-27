using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;



    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
            HandleTutorialInput();
    }

    void HandleTutorialInput()
    {
        if (popUpIndex == 0 && Input.GetKey(KeyCode.W))
        {
            // If W is pressed, move to the next popUp
            popUpIndex++;
        }
        else if (popUpIndex == 1 && Input.GetKey(KeyCode.S))
        {
            // If S is pressed, move to the next popUp
            popUpIndex++;
        }
        else if (popUpIndex == 2 && Input.GetKey(KeyCode.D))
        {
            // If D is pressed, move to the next popUp
            popUpIndex++;
        }
        else if (popUpIndex == 3 && Input.GetKeyDown(KeyCode.A))
        {
            // If A is pressed, move to the next popUp
            popUpIndex++;
        }
         
         else if (popUpIndex == 4 && Input.GetMouseButtonDown(0))
        {
            spawner.SetActive(true);
            popUpIndex++;
        }
         
         else if (popUpIndex == 5 && Input.GetKeyDown(KeyCode.Escape) )
        {
            {popUpIndex++;}
        }
  
    }
}
