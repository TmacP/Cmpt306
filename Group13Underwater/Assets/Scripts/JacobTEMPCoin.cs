using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobTEMPCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // If the collectable is colliding with player, apply powerup
            Destroy(this.gameObject);
        }
    }
}
