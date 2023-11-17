using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float health = 100.0f;

    [SerializeField] private float damageToPlayer = 10.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float shooting_cooldown = 5.0f;
    [SerializeField] private GameObject enemyProjectilePrefab;
    [SerializeField] private float projectileDamage = 10.0f; // Set default damage here
    private float damageTime;

    private bool canShoot = true;
    private float shotTimer = 0.0f;


    private PlayerHealth playerHealth; // Reference to the PlayerHealth script.

    private bool enableDebugLogs = false; // Flag to enable or disable debug logs.
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
        if (enableDebugLogs){Debug.Log("Enemy Start");}//DEBUG
        // Find the PlayerHealth script attached to the player GameObject
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        shotTimer += Time.fixedDeltaTime;
        if(shotTimer >= shooting_cooldown) canShoot = true;
        if(canShoot) Shoot();
        Movement();
    }
private void Movement()
    {
        if (GameManager.instance.player)
        {
            Vector3 targetPosition = GameManager.instance.player.transform.position;
            Vector3 moveDirection = (targetPosition - transform.position).normalized;
            if (moveDirection.magnitude >= 20) transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

private void Shoot(){
        
        shotTimer = 0.0f;

        // Set canShoot to false to prevent shooting during cooldown
        canShoot = false;

        // Get the direction of the player
        Vector3 targetPosition = GameManager.instance.player.transform.position;
        Vector3 shootDirection = (targetPosition - transform.position).normalized;
        // Instantiate the projectile and set its direction and damage
        GameObject newProjectile = Instantiate(enemyProjectilePrefab, transform.position, Quaternion.identity);
        newProjectile.GetComponent<EnemyProjectile>().SetDirection(shootDirection);
        newProjectile.GetComponent<EnemyProjectile>().damage = projectileDamage;

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
