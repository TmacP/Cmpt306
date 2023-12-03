using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // OnTriggerEnter is called when another collider enters this object's collider
    private Spawner spawner; // Reference to the Spawner class
    [SerializeField] private GameObject starParticle;


    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner not found in the scene. Make sure it's present.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager != null)
            {
                gameManager.AddAmmo(25);                                          
                Destroy(this.gameObject);
                gameManager.buffSoundPlay();
                GameObject effect = Instantiate(starParticle, transform.position, transform.rotation);

            if (spawner != null)
            {
                // Pass the reference to the Spawner to decrement the count
                spawner.DecrementCount(this.gameObject);
            }
            }

        }

    }

}


