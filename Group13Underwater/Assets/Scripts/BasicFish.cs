using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Here is a basic fish movement (tilting up and down to make it look swimming)
        // Last two numbers are what we fiddle with, first == speed second == degree of tilting
        //transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 40, 90));
    }
}
