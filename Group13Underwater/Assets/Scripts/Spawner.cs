using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    public GameObject itemPrefab; // Reference to the item prefab
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f; // Adjust this interval as needed
    private float playerYCoordinate;

    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions

    public List<Vector3Int> emptyTilePositions;

    private void Start()
    {
        //if (enableDebugLogs) { Debug.Log("Spawner started."); } //DEBUG
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            //if (enableDebugLogs) { Debug.Log("Time to spawn items."); } //DEBUG
            SpawnItems();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }


    private void SpawnItems()
    {
        //if (enableDebugLogs) { Debug.Log("Spawning items."); } //DEBUG
        //if (enableDebugLogs) { Debug.Log("emptyTilePositions " + string.Join(", ", tileGeneration.emptyTilePositions)); }//DEBUG

        if (tileGeneration.emptyTilePositions.Count == 0)
        {
            //if (enableDebugLogs) { Debug.Log("No empty tile positions available."); } //DEBUG
            return;
        }

        if (itemPrefab == null)
        {
            //if (enableDebugLogs) { Debug.Log("Item prefab is not assigned."); } //DEBUG
            return;
        }

        // Get the player's y coordinate from the GameManager
        float playerYCoordinate = GameManager.instance.GetPlayerPosition().y;
        
        if (enableDebugLogs) { Debug.Log("players Y coor. " + playerYCoordinate); } //DEBUG

        int randomIndex = Random.Range(0, tileGeneration.emptyTilePositions.Count);
        Vector3Int position = tileGeneration.emptyTilePositions[randomIndex];

        // Instantiate the chosen item prefab at the random position
        Vector3 spawnPosition = new Vector3(position.x, position.y, 0);

        if (enableDebugLogs) { Debug.Log("spawn position y coor. " + spawnPosition.y); } //DEBUG

         // Check if the item is in veiw of the player player
        // if (enableDebugLogs) { Debug.Log("playerYCoordinate + spawnPosition.y = :" + (playerYCoordinate + spawnPosition.y)); } //DEBUG
         if (playerYCoordinate <= (spawnPosition.y + 80))
         {
             if (enableDebugLogs) { Debug.Log("Item is  in view of the player."); } //DEBUG
             return;
        }

        // check if the item is too far away from the player
        if (enableDebugLogs) { Debug.Log("playerYCoordinate - spawnPosition.y = :" + (playerYCoordinate - spawnPosition.y)); } //DEBUG
        if ((playerYCoordinate - spawnPosition.y) >=  160)
        {
            if (enableDebugLogs) { Debug.Log("Item is too far from player."); } //DEBUG
            return;
        }
        // check if the item is above player
        if (playerYCoordinate <= spawnPosition.y)
        {
            if (enableDebugLogs) { Debug.Log("Item is above player."); } //DEBUG
            tileGeneration.emptyTilePositions.RemoveAt(randomIndex);
            return;
        }

        // all the checks have passed so spawn the item
        GameObject newlySpawnedEntity = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        // Pass a reference to the spawner to the spawned object
        newlySpawnedEntity.AddComponent<Despawnable>();

    }
}
