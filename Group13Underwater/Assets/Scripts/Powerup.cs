using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public PowerupEffect powerupEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // If the collectable is colliding with player, apply powerup
            powerupEffect.Apply(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
