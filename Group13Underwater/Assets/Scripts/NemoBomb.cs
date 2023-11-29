using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoBomb : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private float bombDamage = 20.0f;
    [SerializeField] private GameObject deathParticle;
    private Spawner spawner; // Reference to the Spawner class


    void Start()
    {
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner not found in the scene. Make sure it's present.");
        }
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && other is CapsuleCollider2D)
        {

            if (playerHealth != null)
            {
                other.transform.GetComponent<PlayerHealth>().TakeDamage(bombDamage);
            }
            Destroy(this.gameObject);
            GameObject effect = Instantiate(deathParticle, transform.position, transform.rotation);
            spawner.nemoMineCount--;

        }
    }
}
