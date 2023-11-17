using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{   
    public GameObject[] popUps;
    private int popUpIndex;
    public GameObject spawner;
    public float waitTime=2.0f;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < popUps.Length; i++){
            if(i==popUpIndex){
                popUps[i].SetActive(true);
            } 
            else {
                popUps[i].SetActive(false);
            }
        }   

       
        if (popUpIndex == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                // If W is pressed, move to the next popUp
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.S))
            {
                // If S is pressed, move to the next popUp
                popUpIndex++;
            }
        }

        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.D))
            {
                // If D is pressed, move to the next popUp
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                // If A is pressed, move to the next popUp
                popUpIndex++;
            }
        }
        else if (popUpIndex == 4)
        {
             if (waitTime <= 0)
                {
                    spawner.SetActive(true);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }

            if (Input.GetMouseButtonDown(0)){
            
            popUpIndex++; }
        }
}

}