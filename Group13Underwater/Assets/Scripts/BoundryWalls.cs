using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryWalls : MonoBehaviour
{
    private bool enableDebugLogs = false; // Control debug logs
    private float WallYcoord;
    private float yOffset = 200f;
    private float delayTime = 10f; // Delay time in seconds

    // Called when the script instance is being loaded

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveWallWithDelay());
    }

    private IEnumerator MoveWallWithDelay()
    {
        while (true)
        {
            moveWall();

            // Wait for the specified delay time
            yield return new WaitForSeconds(delayTime);
        }
    }

    private void moveWall()
    {
        // Get the player's Y-coordinate
        float playerYCoordinate = GameManager.instance.GetPlayerPosition().y;
        if (enableDebugLogs) { Debug.Log("players coord y " + playerYCoordinate); } //DEBUG

        // Set the  wall Y-coordinate
        WallYcoord = transform.position.y;
        if (enableDebugLogs) { Debug.Log("wall coord y " + WallYcoord); } //DEBUG

        // Calculate the difference between the player and the wall
        float distance = Mathf.Abs(Mathf.Abs(WallYcoord) - Mathf.Abs(playerYCoordinate));
        if (enableDebugLogs) { Debug.Log("distance is " + distance); } //DEBUG

        // If the player Y coord is below the threshold, move the walls down
        if (distance >= yOffset)
        {
            if (enableDebugLogs) { Debug.Log("if distance is > 80 move down "); } //DEBUG
            // Calculate the new position of the wall
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y - (distance - yOffset), transform.position.z);

            // Move the wall to the new position
            transform.position = newPosition;
        }
    }
}
