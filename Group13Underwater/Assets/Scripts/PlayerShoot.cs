using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
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

        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // if the player has no ammo, don't shoot
        if (GameManager.instance.ammo <= 0)
        {
            return;
        }

        // Reduce ammo by 1
        GameManager.instance.ammo -= 1;
        GameManager.instance.UpdateAmmoVisual();

        // Play the shoot sound
        shootSound.Play();
        // Reset the shot timer when shooting
        shotTimer = 0.0f;

        // Set canShoot to false to prevent shooting during cooldown
        canShoot = false;

        // Get the mouse position in screen coordinates and convert it to a world point
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f; // Set the distance from the camera

        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the direction to the mouse position
        Vector3 shootDirection = (targetPosition - transform.position).normalized;

        // Instantiate the projectile and set its direction and damage
        GameObject newProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Projectile>().SetDirection(shootDirection);
        newProjectile.GetComponent<Projectile>().damage = projectileDamage;
    }

    void FixedUpdate()
    {
        if (shotTimer >= shotCooldown)
        {
            // The cooldown time has passed, allow shooting
            canShoot = true;
        }
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

