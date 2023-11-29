using System.Collections;
using UnityEngine;

/// <summary>
/// THIS CLASS IS FOR ENTITIES THAT DESPAWN WHEN THEY GET TO FAR ABOVE THE PLAYER 
/// 
/// WHENEVER YOU SPAWN AN ENTITY THAT YOU WANT TO DESPAWN GIVE IT THIS
/// -Steven
/// </summary>
public class Despawnable : MonoBehaviour
{
    private int despawnOffset = 80;
    private Spawner spawner; // Reference to the Spawner class


    private void Awake()
    {
        spawner = FindObjectOfType<Spawner>(); // Find the Spawner in the scene
        StartCoroutine(checkForDespawn());
    }


    private IEnumerator checkForDespawn()
    {
        if (GameManager.instance.GetPlayerPosition().y < gameObject.transform.position.y - despawnOffset)
        {
            Destroy(gameObject);
            // Call the despawn function in the Spawner
            spawner.DecrementCount(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(1);
            StartCoroutine(checkForDespawn());
        }

    }

}
