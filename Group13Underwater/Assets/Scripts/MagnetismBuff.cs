using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MagnetBuff")]
public class MagnetismBuff : PowerupEffect
{
    public float maxBuffDuration; // The max duration of the buff
    public float remainingBuffDuration; // How much time is left on the buff
    private bool isBuffed = false;

    public override void Apply(GameObject target)
    {
        MonoBehaviour monoBehaviour = target.GetComponent<MonoBehaviour>();
        isBuffed = false;
        monoBehaviour.StartCoroutine(Pickup(target));
        if (!isBuffed)
        {
            remainingBuffDuration = maxBuffDuration;
            monoBehaviour.StartCoroutine(Pickup(target));
        }
        else {
            remainingBuffDuration = maxBuffDuration;
        }
    }

    IEnumerator Pickup(GameObject target) {
        Debug.Log("Power-up Picked Up"); // Temp Message


        // Spawn an effect so that the player knows something occured:

        // Apply MoveSpeed Buff
        JacobTEMPPlayer player = target.GetComponent<JacobTEMPPlayer>(); // get player data, can change
        isBuffed = true; // set isBuffed to true

        player.hasMagnetBuff = true;

        while (remainingBuffDuration > 0f)
        {
            yield return null; // Return nothing
            remainingBuffDuration -= Time.deltaTime; // Decrease the remaining duration
        }
        player.hasMagnetBuff = false;
        isBuffed = false; // Player is no longer buffed
    }
}
