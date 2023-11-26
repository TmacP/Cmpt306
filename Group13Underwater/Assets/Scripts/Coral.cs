using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : MonoBehaviour
{
    [SerializeField] private GameObject bubbles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void TakeDamage(float damage)
    {
 
        Destroy(this.gameObject);
        GameObject effect = Instantiate(bubbles, transform.position, transform.rotation);
    }
}
