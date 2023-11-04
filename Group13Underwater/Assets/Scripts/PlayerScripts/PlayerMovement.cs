using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1000;
    [SerializeField] Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.up * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * moveSpeed);

            if (spriteRenderer.flipX == false) {
                spriteRenderer.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * moveSpeed);

            if (spriteRenderer.flipX == true) {
                spriteRenderer.flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.down * moveSpeed);
        }
    }
}
