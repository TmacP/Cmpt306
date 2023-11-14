using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobTEMPCoin : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        GameManager gameManager = GameManager.instance;
        if (gameManager != null)
        {
            gameManager.AddMoney(1);
            if (enableDebugLogs) Debug.Log("Money added when item was collected."); //DEBUG
            // If the collectable is colliding with player, apply powerup
            Destroy(this.gameObject);
        }

        }





    }

}
