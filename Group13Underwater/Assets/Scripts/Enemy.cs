using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Default Enemy stats
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] public float health = 100.0f;

    [SerializeField] private float damageToPlayer = 20.0f;
    [SerializeField] private float damageRate = 0.2f;
    [SerializeField] private float damageTime;

    private void Start()
    {
    }
    void FixedUpdate()
    {
        Movement();
    }

private void Movement()
{
    if (GameManager.instance.player)
    {
        Vector3 targetPosition = GameManager.instance.player.transform.position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
                            //GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
                            //Destroy(effect, 1.0f);
            //Destroy(this.gameObject);
                            //GameManager.instance.AddPoints(1);    
                            //Instantiate(deathDrop, transform.position, Quaternion.identity);
        }

    }
    
    //void OnTriggerStay(Collider other)
    //{
        //if (other.transform.tag == "Player" && Time.time > damageTime && other is BoxCollider)
        //{
            //other.transform.GetComponent<Player>().TakeDamage(damageToPlayer);
            //damageTime = Time.time + damageRate;
        //}
   //}
}
