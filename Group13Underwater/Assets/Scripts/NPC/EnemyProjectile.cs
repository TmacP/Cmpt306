using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float moveSpeed = 50.0f;
    public float damage = 10.0f; // Made public for visibility, can be set directly if needed
    private Vector3 direction;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        MoveProjectile();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void MoveProjectile()
    {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null)
        {
            return; // Exit the method if 'other' is null
        }
        if (other.CompareTag("Player"))
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }

    // Public method to set the damage from external scripts if needed
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
}
