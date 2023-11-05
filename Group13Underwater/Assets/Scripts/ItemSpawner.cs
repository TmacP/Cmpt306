using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private bool enableDebugLogs = true; // Control debug logs
    public GameObject ScoreCollectable; // Reference to the prefab ScoreCollectable
    public GameObject HealBuffCollectable; // Reference to the prefab HealBuffCollectable
    public GameObject MagnetBuffCollectable; // Reference to the prefab MagnetBuffCollectable
    public GameObject MoveSpeedBuffCollectable; // Reference to the prefab MoveSpeedBuffCollectable
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f; // Adjust this interval as needed

    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions

    public List<Vector3Int> emptyTilePositions;

    private void Start()
    {
        if (enableDebugLogs) { Debug.Log("ItemSpawner started."); } //DEBUG
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
        if (enableDebugLogs){Debug.Log("emptyTilePositions " + string.Join(", ", tileGeneration.emptyTilePositions));}//DEBUG

        if (tileGeneration.emptyTilePositions.Count == 0)
        {
            if (enableDebugLogs) { Debug.Log("No empty tile positions available."); } //DEBUG
            return;
        }

        GameObject itemPrefab = GetRandomItemPrefab(); // Get a random item prefab

        if (itemPrefab == null)
        {
            if (enableDebugLogs) { Debug.Log("No item prefabs available."); } //DEBUG
            return;
        }

        int randomIndex = Random.Range(0, tileGeneration.emptyTilePositions.Count);
        Vector3Int position = tileGeneration.emptyTilePositions[randomIndex];

        // Instantiate the chosen item prefab at the random position
        Vector3 spawnPosition = new Vector3(position.x, position.y, 0);
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        if (enableDebugLogs) { Debug.Log("Spawned item at position: " + spawnPosition); } //DEBUG
        // Remove the used position from the list
        tileGeneration.emptyTilePositions.RemoveAt(randomIndex);

    }



    private GameObject GetRandomItemPrefab()
    {
        if (enableDebugLogs) { Debug.Log("Getting a random item prefab."); } //DEBUG

        GameObject[] itemPrefabs = { ScoreCollectable, HealBuffCollectable, MagnetBuffCollectable, MoveSpeedBuffCollectable };

        int randomIndex = Random.Range(0, itemPrefabs.Length);
        if (enableDebugLogs) { Debug.Log("Chose item prefab: " + itemPrefabs[randomIndex].name); } //DEBUG

        return itemPrefabs[randomIndex];
    }
}
