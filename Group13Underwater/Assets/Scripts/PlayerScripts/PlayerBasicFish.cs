using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicFish : MonoBehaviour
{
    // When the player contacts a fish, add point and destroy fish
    
    private Spawner spawner; // Reference to the Spawner class

    private void Start()
    {
        spawner = FindObjectOfType<Spawner>(); // Find the Spawner in the scene
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "BasicFish" && (GameManager.instance != null))
        {

                // Add a point
                GameManager.instance.AddScore(1);


            // Destroy the fish instance
            Destroy(other.gameObject);
            spawner.basicFishCount--;

        }
        if (other.transform.tag == "UncommonFish" && (GameManager.instance != null))
        {

            // Add a point
            GameManager.instance.AddScore(2);


            // Destroy the fish instance
            Destroy(other.gameObject);
            spawner.uncommonFishCount--;

        }
        if (other.transform.tag == "SpecialFish" && (GameManager.instance != null))
        {

            // Add a point
            GameManager.instance.AddScore(3);


            // Destroy the fish instance
            Destroy(other.gameObject);
            spawner.specialFishCount--;

        }
        if (other.transform.tag == "RareFish" && (GameManager.instance != null))
        {

            // Add a point
            GameManager.instance.AddScore(4);


            // Destroy the fish instance
            Destroy(other.gameObject);
            spawner.legendaryFishCount--;


        }
        if (other.transform.tag == "LegendFish" && (GameManager.instance != null))
        {

            // Add a point
            GameManager.instance.AddScore(6);


            // Destroy the fish instance
            Destroy(other.gameObject);
            spawner.rareFishCount--;
        }
    }

}















