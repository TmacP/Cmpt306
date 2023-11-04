using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MoveSpeedBuff")]
public class MoveSpeedBuff : PowerupEffect
{
    public float speedMultiplier; 
    public float maxBuffDuration; 
    private bool isBuffed = false;
    private bool enableDebugLogs = true; // Control debug logs

    public override void Apply(GameObject target)
    {
        PlayerMovement player = target.GetComponent<PlayerMovement>();

        if (player != null && !isBuffed)
        {
            MonoBehaviour monoBehaviour = target.GetComponent<MonoBehaviour>();
            monoBehaviour.StartCoroutine(Pickup(player)); // Start the Pickup coroutine
            if (enableDebugLogs) Debug.Log("Pickup Speed Buff"); // Debug log with comment
        }
    }

    IEnumerator Pickup(PlayerMovement player)
    {
        if (enableDebugLogs) Debug.Log("Power-up Picked Up #DEBUG"); // Debug log with comment

        isBuffed = true;
        player.moveSpeed *= speedMultiplier;

        float timer = maxBuffDuration;
        while (timer > 0f)
        {
            if (enableDebugLogs) Debug.Log("Remaining Buff Duration: " + timer + " seconds #DEBUG"); // Debug log for remaining duration
            yield return null;
            timer -= Time.deltaTime;
        }

        if (enableDebugLogs) Debug.Log("Buff Expired #DEBUG"); // Debug log for buff expiration
        player.moveSpeed /= speedMultiplier;
        isBuffed = false;
    }
}
