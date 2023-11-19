using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    public GameObject itemPrefab; // Reference to the item prefab
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f; // Adjust this interval as needed

    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions

    public List<Vector3Int> emptyTilePositions;

    private void Start()
    {
        if (enableDebugLogs) { Debug.Log("Spawner started."); } //DEBUG
        SpawnItems();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (enableDebugLogs) { Debug.Log("Time to spawn items."); } //DEBUG
            SpawnItems();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnItems()
    {
        if (enableDebugLogs) { Debug.Log("Spawning items."); } //DEBUG
        if (enableDebugLogs) { Debug.Log("emptyTilePositions " + string.Join(", ", tileGeneration.emptyTilePositions)); }//DEBUG

        if (tileGeneration.emptyTilePositions.Count == 0)
        {
            if (enableDebugLogs) { Debug.Log("No empty tile positions available."); } //DEBUG
            return;
        }

        if (itemPrefab == null)
        {
            if (enableDebugLogs) { Debug.Log("Item prefab is not assigned."); } //DEBUG
            return;
        }

        int randomIndex = Random.Range(0, tileGeneration.emptyTilePositions.Count);
        Vector3Int position = tileGeneration.emptyTilePositions[randomIndex];

        // Instantiate the chosen item prefab at the random position
        Vector3 spawnPosition = new Vector3(position.x, position.y, 0);
        GameObject newlySpawnedEntity = Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        newlySpawnedEntity.AddComponent<Despawnable>();


        if (enableDebugLogs) { Debug.Log("Spawned item at position: " + spawnPosition); } //DEBUG
        // Remove the used position from the list
        //tileGeneration.emptyTilePositions.RemoveAt(randomIndex);
    }
}
