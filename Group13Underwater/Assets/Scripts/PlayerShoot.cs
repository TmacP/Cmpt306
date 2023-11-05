using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float shotCooldown = 2.0f;
    
    private bool canShoot = true;
    private float shotTimer = 0.0f;

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

        // Instantiate the projectile and set its direction
        GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
        newProjectile.GetComponent<Projectile>().SetDirection(shootDirection);
    }

    void FixedUpdate()
    {
        if (shotTimer >= shotCooldown)
        {
            // The cooldown time has passed, allow shooting
            canShoot = true;
        }
    }
}
