using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float health = 100.0f;
    [SerializeField] private float damageToPlayer = 10.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float wiggleSpeed = 5.0f;
    private float damageTime;

    private PlayerHealth playerHealth;
    private bool enableDebugLogs = false;
    private Vector2 swimDirection;
    [SerializeField] private GameObject deathParticle;
    

    private SpriteRenderer spriteRenderer; // Added SpriteRenderer reference

    private void Start()
    {
        int enemyKilled = GameManager.instance.enemyKilled;
        health += enemyKilled;
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get SpriteRenderer component
        if (enableDebugLogs) { Debug.Log("Enemy Start with health: " + health); }
        StartCoroutine(Wiggle());
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

            // Update swim direction
            swimDirection = new Vector2(moveDirection.x, moveDirection.y);

            // Flip the sprite based on the swim direction
            if (swimDirection.x > 0)
            {
                if (!spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = true;
                }
            }
            else if (swimDirection.x < 0)
            {
                if (spriteRenderer.flipX)
                {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }

    private IEnumerator Wiggle()
    {
        while (true)
        {
            float wiggleOffset = Mathf.Sin(Time.time * wiggleSpeed) * 0.5f;
            Vector3 newRotation = new Vector3(0, 0, wiggleOffset * 15);
            transform.localEulerAngles = newRotation;

            yield return null;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            GameManager.instance.AddEnemyKilled(1);
            GameManager.instance.AddScore(1);
            GameObject effect = Instantiate(deathParticle, transform.position, transform.rotation);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if (enableDebugLogs) { Debug.Log("On trigger stay"); }
        if (other.transform.tag == "Player" && Time.time > damageTime && other is CapsuleCollider2D)
        {
            //if (enableDebugLogs) { Debug.Log("Enemy is colliding with " + other.transform.tag); }

            if (playerHealth != null)
            {
                other.transform.GetComponent<PlayerHealth>().TakeDamage(damageToPlayer);
                damageTime = Time.time + damageRate;
            }
        }
    }
}
