using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coral : MonoBehaviour
{
    [SerializeField] private GameObject bubbles;
    private Spawner spawner; // Reference to the Spawner class


    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner not found in the scene. Make sure it's present.");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        public void TakeDamage(float damage)
    {
 
        Destroy(this.gameObject);
        GameObject effect = Instantiate(bubbles, transform.position, transform.rotation);
        if (spawner != null)
        {
            // Pass the reference to the Spawner to decrement the count
            spawner.DecrementCount(this.gameObject);
        }

    }
}
