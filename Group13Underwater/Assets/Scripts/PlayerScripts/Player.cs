using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject basicFish;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // When the player contacts a fish, add point and destroy fish
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "BasicFish")
        {
            // Add a point
            GameManager.instance.AddScore(1);
            // Destroy the fish instance
            Destroy(this.gameObject);
        }
    }
}

