using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damageToPlayer = 10.0f;
    [SerializeField] private float damageRate = 0.2f;
    private float damageTime;

    private PlayerHealth playerHealth;
    private bool enableDebugLogs = false;

    [SerializeField] private float fieldOfViewAngle = 90f;
    [SerializeField] private float visionRange = 20f;

    private void Start()
    {
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
        if (enableDebugLogs) { Debug.Log("Enemy Start"); } // DEBUG
    }

    private void FixedUpdate()
    {
        // Check if the player is within the field of view
        if (IsPlayerInFieldOfView())
        {
            // Move towards the player
            MoveTowardsPlayer();
        }
    }

    private bool IsPlayerInFieldOfView()
    {
        //if (GameManager.instance.player)
        //{
            Vector3 directionToPlayer = GameManager.instance.player.transform.position - transform.position;
            float angleToPlayer = Vector3.Angle(transform.up, directionToPlayer);

            if (angleToPlayer < fieldOfViewAngle * 0.5f)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, visionRange);

                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        //}

        return false;
    }

    private void MoveTowardsPlayer()
    {
        Vector3 targetPosition = GameManager.instance.player.transform.position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (enableDebugLogs) { Debug.Log("On trigger stay"); } // DEBUG
        if (other.transform.tag == "Player" && Time.time > damageTime && other is CapsuleCollider2D)
        {
            if (enableDebugLogs) { Debug.Log("Enemy is colliding with " + other.transform.tag); }

            if (playerHealth != null)
            {
                other.transform.GetComponent<PlayerHealth>().TakeDamage(damageToPlayer);
                damageTime = Time.time + damageRate;
            }
        }
    }
}
