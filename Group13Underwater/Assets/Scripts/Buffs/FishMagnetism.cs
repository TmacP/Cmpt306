using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls the magnetism of an item toward the player.

/// </summary>
public class FishMagnetism : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    private bool enableDebugLogs = true; // Control debug logs

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && collision.GetComponent<PlayerBuff>().hasMagnetBuff)
        {
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, moveSpeed * Time.deltaTime);
            if (enableDebugLogs) Debug.Log("Item moved towards player."); //DEBUG
            //if (Vector2.Distance(transform.position, collision.transform.position) < 0.1f);
        }
    }

}
