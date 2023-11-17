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

        if (popUpIndex==0){
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
                popUpIndex++;
            }
            else if (Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)){
                popUpIndex++;
            }
            else if(popUpIndex==2){
                if(waitTime<=0){
                    spawner.SetActive(true);
                } else {
                    waitTime -= Time.deltaTime;
                }
            }
    }
}
}