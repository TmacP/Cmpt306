using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobTEMPPlayer : MonoBehaviour
{
    /*
     THIS PLAYER SCRIPT IS A TEMPORARY ONE TO TEST COLLECTABLES
    IT WILL BE REPLACED WITH THE ACTUAL ONE WHEN MERGING LATER
    I JUST WANT TO MAKE SURE I CAN GIVE POWER-UPS
     */

    public float moveSpeed = 5.0f;
    public float health = 50f;
    public bool hasMagnetBuff;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    /*
     * Temp Basic Movement script
     */
    private void Movement() {
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

    }
}
