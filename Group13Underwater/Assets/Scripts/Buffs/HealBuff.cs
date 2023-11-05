using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealBuff")]
public class HealBuff : PowerupEffect
{
    public float healAmount;
    public override void Apply(GameObject target)
    {
        if (target.GetComponent<PlayerHealth>().playerHealth < 100.0f)
        {
            if ( (target.GetComponent<PlayerHealth>().playerHealth + healAmount) > 100.0f) {
                target.GetComponent<PlayerHealth>().playerHealth = 100.0f;
            }
            target.GetComponent<PlayerHealth>().playerHealth += healAmount;
        }
    }
}
