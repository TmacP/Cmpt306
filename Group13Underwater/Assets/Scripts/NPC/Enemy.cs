using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Default Enemy stats
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float health = 100.0f;

    [SerializeField] private float damageToPlayer = 20.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;

    private PlayerHealth playerHealth; // Reference to the PlayerHealth script.

    private bool enableDebugLogs = false; // Flag to enable or disable debug logs.

    private void Start()
    {
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
        if (enableDebugLogs){Debug.Log("Enemy Start");}//DEBUG
        // Find the PlayerHealth script attached to the player GameObject.
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (GameManager.instance.player)
        {
            Vector3 targetPosition = GameManager.instance.player.transform.position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Handle enemy death logic.
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (enableDebugLogs){Debug.Log("On trigger stay");}// DEBUG
        if (other.transform.tag == "Player" && Time.time > damageTime && other is CapsuleCollider2D)
        {
            if (enableDebugLogs){Debug.Log("Enemy is colliding with " + other.transform.tag);}

            if (playerHealth != null)
            {
                other.transform.GetComponent<PlayerHealth>().TakeDamage(damageToPlayer);
                damageTime = Time.time + damageRate;
            }
        }
    }
}
