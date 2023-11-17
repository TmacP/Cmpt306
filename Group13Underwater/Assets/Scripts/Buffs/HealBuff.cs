using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealBuff")]
public class HealBuff : PowerupEffect
{
    private bool enableDebugLogs = false; // Control debug logs

    [SerializeField] public float healAmount;
public override void Apply(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = target.GetComponent<PlayerMovement>();

        if (playerHealth != null && playerMovement != null)
        {
            if (enableDebugLogs) { Debug.Log("Health before heal:" + playerHealth.playerHealth); } // DEBUG

            if (playerHealth.playerHealth < playerHealth.fullHealth)
            {
                if ((playerHealth.playerHealth + healAmount) > playerHealth.fullHealth)
                {
                    playerHealth.playerHealth = playerHealth.fullHealth;
                    if (enableDebugLogs) { Debug.Log("Health after heal:" + playerHealth.playerHealth); } // DEBUG
                }
                else
                {
                    playerHealth.playerHealth += healAmount;
                    if (enableDebugLogs) { Debug.Log("Health after heal:" + playerHealth.playerHealth); } // DEBUG
                }
            }
            else
            {
                if (enableDebugLogs) { Debug.Log("Health after heal:" + playerHealth.playerHealth); } // DEBUG
            }

            // Example usage from another script
            /*if (playerMovement != null)
            {
                playerMovement.ResetMoveSpeed();
            }*/
        }
    }
}

