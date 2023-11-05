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
        if (enableDebugLogs) { Debug.Log("Health before heal:" + target.GetComponent<PlayerHealth>().playerHealth); } //DEBUG

        if (target.GetComponent<PlayerHealth>().playerHealth < 100.0f)
        {
            if ((target.GetComponent<PlayerHealth>().playerHealth + healAmount) > 100.0f)
            {
                target.GetComponent<PlayerHealth>().playerHealth = 100.0f;
                if (enableDebugLogs) { Debug.Log("Health after heal:" + target.GetComponent<PlayerHealth>().playerHealth); } //DEBUG
            }
            else
            {
                target.GetComponent<PlayerHealth>().playerHealth += healAmount;
                if (enableDebugLogs) { Debug.Log("Health after heal:" + target.GetComponent<PlayerHealth>().playerHealth); } //DEBUG

            }
        }
        else
        {
            if (enableDebugLogs) { Debug.Log("Health after heal:" + target.GetComponent<PlayerHealth>().playerHealth); } //DEBUG
        }
    }
}
