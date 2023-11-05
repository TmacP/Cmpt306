using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicFish : MonoBehaviour
{
    // When the player contacts a fish, add point and destroy fish
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "BasicFish" && (GameManager.instance != null))
        {

                // Add a point
                GameManager.instance.AddScore(1);


            // Destroy the fish instance
            Destroy(other.gameObject);
        }
    }
}
