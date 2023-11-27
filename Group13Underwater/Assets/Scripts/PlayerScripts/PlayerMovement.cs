using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
 // Public property to access and modify moveSpeed
    public float moveSpeed = 1000;
    
    private float originalMoveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    [SerializeField] Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the original speed during initialization
        originalMoveSpeed = moveSpeed;
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

                transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 15, 5));
    }

        // Function to reset the speed to its original value
    public void ResetMoveSpeed()
    {
        moveSpeed = originalMoveSpeed;
    }
}
