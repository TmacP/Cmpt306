using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MoveSpeedBuff")]
public class MoveSpeedBuff : PowerupEffect
{
    public float speedMultiplier; // The muliplier to increase speed
    public float maxBuffDuration; // The max duration of the buff
    public float remainingBuffDuration; // How much time is left on the buff
    private bool isBuffed = false;

    public override void Apply(GameObject target)
    {
        /* Need to get MonoBehaviour so that we can use Coroutines, which are nice
         * for having Power-ups only last temporarily
        */
        MonoBehaviour monoBehaviour = target.GetComponent<MonoBehaviour>();
        // If the target is NOT buffed, run the Pickup coroutine
        if (!isBuffed) 
        {
            remainingBuffDuration = maxBuffDuration;
            monoBehaviour.StartCoroutine(Pickup(target));
        }
        else
        {
            // If the Target IS buffed, refresh the buff duration without altering
            // the movespeed or anything
            remainingBuffDuration = maxBuffDuration; 
        }
}

IEnumerator Pickup(GameObject target)
    {
        Debug.Log("Power-up Picked Up"); // Temp Message
        

        // Spawn an effect so that the player knows something occured:

        // Apply MoveSpeed Buff
        PlayerMovement player = target.GetComponent<PlayerMovement>(); // get player data, can change
        isBuffed = true; // set isBuffed to true

        player.moveSpeed *= speedMultiplier; // increase movement speed by multiplier

        while (remainingBuffDuration > 0f)
        {
            yield return null; // Return nothing
            remainingBuffDuration -= Time.deltaTime; // Decrease the remaining duration
        }
        player.moveSpeed /= speedMultiplier; // Revert MS buff
        isBuffed = false; // Player is no longer buffed
    }


}
