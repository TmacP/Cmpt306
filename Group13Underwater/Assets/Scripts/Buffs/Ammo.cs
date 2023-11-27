using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    // OnTriggerEnter is called when another collider enters this object's collider

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager != null)
            {
                gameManager.AddAmmo(25);                                          
                Destroy(this.gameObject);
            }

        }

    }

}


