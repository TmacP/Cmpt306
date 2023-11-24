using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemoBomb : MonoBehaviour
{
    private PlayerHealth playerHealth;
    [SerializeField] private float bombDamage = 25.0f;

    void Start()
    {
        playerHealth = GameManager.instance.player.GetComponent<PlayerHealth>();
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
        }
    }
}
