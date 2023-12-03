using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacobTEMPCoin : MonoBehaviour
{
    private Spawner spawner; // Reference to the Spawner class
    private bool enableDebugLogs = false; // Control debug logs

    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner not found in the scene. Make sure it's present.");
        }
    }
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
                //spawner.scoreCollectableCount--; //HACK this is to fix a bug that causes the score to go down when a collectable is despawned.
            }

        }

    }

}
