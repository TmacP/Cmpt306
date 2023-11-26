using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float shotCooldown = 1.0f;
    [SerializeField] private float projectileDamage = 10.0f; // Set default damage here

    private bool canShoot = true;
    private float shotTimer = 0.0f;

    public AudioSource shootSound; // Assign in Unity Editor

    void Update()
    {
        // Update the shot timer
        shotTimer += Time.deltaTime;

        if (canShoot)
        {
            Shoot();
        }
    }

void Shoot()
{
    // Play the shoot sound
    shootSound.Play();
    // Reset the shot timer when shooting
    shotTimer = 0.0f;

    // Set canShoot to false to prevent shooting during cooldown
    canShoot = false;

    // Find the player's position (you may need to adjust this based on your game logic)
    GameObject player = GameObject.FindWithTag("Player");
    
    if (player != null)
    {
        // Calculate the direction to the player
        Vector3 shootDirection = (player.transform.position - transform.position).normalized;

        // Instantiate the projectile and set its direction and damage
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        newProjectile.GetComponent<EnemyProjectile>().SetDirection(shootDirection);
        newProjectile.GetComponent<EnemyProjectile>().damage = projectileDamage;
    }

    // Start the cooldown timer
    StartCoroutine(ShotCooldown());
}

    IEnumerator ShotCooldown()
    {
        yield return new WaitForSeconds(shotCooldown);

        // The cooldown time has passed, allow shooting
        canShoot = true;
    }

    // Function to set the projectile damage from external scripts
    public void SetProjectileDamage(float damage)
    {
        projectileDamage = damage;
    }

    // Function to get the current projectile damage
    public float GetProjectileDamage()
    {
        return projectileDamage;
    }
}
