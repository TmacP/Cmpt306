using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TreasureChest : MonoBehaviour
{
    public GameObject itemPrefab1; // Reference to the item prefab - health
    public GameObject itemPrefab2; // Reference to the item prefab - money
    public GameObject itemPrefab3; // Reference to the item prefab - money
    public GameObject itemPrefab4; // Reference to the item prefab - money
    private Spawner spawner; // Reference to the Spawner class

    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        if (spawner == null)
        {
            Debug.LogError("Spawner not found in the scene. Make sure it's present.");
        }
    }
    void Update()
    {   
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Player" && other is CapsuleCollider2D)
        {

            Vector3 spawnPosition1 = new Vector3(transform.position.x+1, transform.position.y, 0);
            Vector3 spawnPosition2 = new Vector3(transform.position.x-1, transform.position.y, 0);
            Vector3 spawnPosition3 = new Vector3(transform.position.x, transform.position.y+1, 0);
            Vector3 spawnPosition4 = new Vector3(transform.position.x, transform.position.y-1, 0);

            GameObject newlyAddedItem;
            newlyAddedItem = Instantiate(itemPrefab1, spawnPosition1, Quaternion.identity);
            newlyAddedItem.AddComponent<Despawnable>();
            spawner.healthCount++;

            newlyAddedItem = Instantiate(itemPrefab2, spawnPosition2, Quaternion.identity);
            newlyAddedItem.AddComponent<Despawnable>();
            spawner.scoreCollectableCount++;

            newlyAddedItem = Instantiate(itemPrefab3, spawnPosition3, Quaternion.identity);
            newlyAddedItem.AddComponent<Despawnable>();
            spawner.scoreCollectableCount++;

            newlyAddedItem = Instantiate(itemPrefab4, spawnPosition4, Quaternion.identity);
            newlyAddedItem.AddComponent<Despawnable>();
            spawner.scoreCollectableCount++;

            Destroy(this.gameObject);
            spawner.treasureChestCount--;

        }
    }
}
