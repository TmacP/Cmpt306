using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float moveSpeed = 50.0f;
    [SerializeField] private float damage = 50.0f;
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
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(this.gameObject); // after bullet hits enemy, destroy bullet
        }
    }
}
