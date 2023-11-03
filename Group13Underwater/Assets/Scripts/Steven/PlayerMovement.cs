using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private int speed = 10000;
    [SerializeField] Rigidbody2D rb;
    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * speed);
        }
    }
}
