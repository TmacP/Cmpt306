using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealBuff")]
public class HealBuff : PowerupEffect
{
    private bool enableDebugLogs = false; // Control debug logs

    [SerializeField] public float healAmount; //currently stuck at 50 for some reason LR Nov 5
public override void Apply(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        PlayerMovement playerMovement = target.GetComponent<PlayerMovement>();

        if (playerHealth != null && playerMovement != null)
        {
            if (enableDebugLogs) { Debug.Log("Health before heal:" + playerHealth.playerHealth); } // DEBUG

            if (playerHealth.playerHealth < 100.0f)
            {
                if ((playerHealth.playerHealth + healAmount) > 100.0f)
                {
                    playerHealth.playerHealth = 100.0f;
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
            /*if (playerMovement != null && playerHealth.playerHealth >= 20)
            {
                playerMovement.ResetMoveSpeed();
            }*/
        }
    }
}

