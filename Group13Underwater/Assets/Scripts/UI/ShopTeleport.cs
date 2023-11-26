using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTeleport : MonoBehaviour
{
    private bool enableDebugLogs = true; // Control debug logs
    public GameObject itemPrefab; // Reference to the item prefab
    public TileGeneration tileGeneration; // Reference to the TileGeneration script which has our list of empty tile positions
    public float teleportInterval = 10f; // Adjust this interval as needed
    private float nextTeleportTime = 0f;

    void Start()
    {
        // You can optionally check if tileGeneration is assigned here
        // Set the initial teleport time
        nextTeleportTime = Time.time + teleportInterval;
    }

    void Update()
    {
        // Check if it's time to teleport
        if (Time.time >= nextTeleportTime)
        {
            TeleportShop();
            // Update the next teleport time
            nextTeleportTime = Time.time + teleportInterval;
        }
    }

    void TeleportShop()
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

        // If we made it this far, we can teleport the shop
            // Move the shop to the new position
            transform.position = spawnPosition;


    }
}
