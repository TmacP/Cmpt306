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
    private Spawner spawner; // Reference to the Spawner script which has our list of empty tile positions

    // Assign the spawner when the object is spawned
    public void SetSpawner(Spawner _spawner)
    {
        spawner = _spawner;
    }


    private void Awake()
    {
        StartCoroutine(checkForDespawn());
    }


    private IEnumerator checkForDespawn()
    {
        if (GameManager.instance.GetPlayerPosition().y < gameObject.transform.position.y - despawnOffset)
        {

            // Call a method in the spawner to decrement the spawnedItems list
            if (spawner != null) {
                spawner.DecrementSpawnedItemsList(gameObject);
            }
            Destroy(gameObject);
                    }
        else
        {
            yield return new WaitForSeconds(10);
            StartCoroutine(checkForDespawn());
        }

    }

}
