using System.Collections;
using UnityEngine;

/// <summary>
/// THIS CLASS IS FOR ENTITIES THAT DESPAWN WHEN THEY GET TOO FAR ABOVE THE PLAYER 
/// 
/// WHENEVER YOU SPAWN AN ENTITY THAT YOU WANT TO DESPAWN GIVE IT THIS
/// -Steven
/// </summary>
public class Despawnable : MonoBehaviour
{
    private int despawnOffset = 80;
    private Spawner spawner; // Reference to the spawner that spawned this object

    // Assign the spawner when the object is spawned
    public void SetSpawner(Spawner _spawner)
    {
        spawner = _spawner;
    }

    private void Awake()
    {
        StartCoroutine(CheckForDespawn());
    }

    private IEnumerator CheckForDespawn()
    {
        if (GameManager.instance.GetPlayerPosition().y < gameObject.transform.position.y - despawnOffset)
        {
            // Call a method in the spawner to decrement the spawnedItems list
            spawner.DecrementSpawnedItemsList(gameObject);

            // Destroy the object
            Destroy(gameObject);
        }
        else
        {
            yield return new WaitForSeconds(10);
            StartCoroutine(CheckForDespawn());
        }
    }
}
