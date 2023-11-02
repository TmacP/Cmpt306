using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/HealBuff")]
public class HealBuff : PowerupEffect
{
    public float healAmount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<JacobTEMPPlayer>().health += healAmount;
    }
}
