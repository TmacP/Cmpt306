using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private Spawner spawner; // Reference to the Spawner class
    public PowerupEffect powerupEffect;
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
            // If the collectable is colliding with player, apply powerup
            powerupEffect.Apply(collision.gameObject);
            Destroy(this.gameObject);
            GameObject effect = Instantiate(starParticle, transform.position, transform.rotation);
            GameManager gameManager = GameManager.instance;
            gameManager.buffSoundPlay();
            if (spawner != null)
            {
                // Pass the reference to the Spawner to decrement the count
                spawner.DecrementCount(this.gameObject);
            }
        }
    }
}
