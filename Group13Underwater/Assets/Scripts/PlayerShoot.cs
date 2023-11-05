using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // setting up the variable that the player will need
    [SerializeField] private float shootCooldown = 0.00f;
    [SerializeField] private GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        Shoot();
        if (shootCooldown >= 0) {
            shootCooldown = shootCooldown - 1.0f;
        }
    }


    void Shoot() {
        if ((Input.GetKey("space") || Input.GetKey(KeyCode.Mouse0)) && shootCooldown <= 0) {
            Instantiate(projectile, transform.position, transform.rotation);
            shootCooldown = 20.00f;
        }
    }

}
