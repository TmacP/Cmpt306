using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    public GameObject ScoreCollectable; // Reference to the prefab ScoreCollectable
    public GameObject HealBuffCollectable; // Reference to the prefab HealBuffCollectable
    public GameObject MagnetBuffCollectable; // Reference to the prefab MagnetBuffCollectable
    public GameObject MoveSpeedBuffCollectable; // Reference to the prefab MoveSpeedBuffCollectable


    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions

    public List<Vector3Int> emptyTilePositions;

    private void Start()
    {
        // Spawn items at random positions from the emptyTilePositions list
        SpawnItems();
        if (enableDebugLogs){Debug.Log("emptyTilePositions: " + string.Join(", ", emptyTilePositions));}//DEBUG


    }

    private void SpawnItems()
    {
        foreach (Vector3Int position in emptyTilePositions)
        {
            // Instantiate the item prefab at a random position from the list
            Vector3 spawnPosition = new Vector3(position.x, position.y, 0); // Adjust the z-coordinate as needed
            Instantiate(ScoreCollectable, spawnPosition, Quaternion.identity);
        }
    }
}
