using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool enableDebugLogs = false;
    public GameObject enemy;
    private float nextSpawnTime = 0f;
    public float spawnInterval = 2f;

    public TileGeneration tileGeneration;
    public List<Vector3Int> emptyTilePositions;

    public float zoomDuration = 2f;
    public float zoomedOutSize = 5f;

    private void Start()
    {
        if (enableDebugLogs) { Debug.Log("Enemy Spawner started."); }
        SpawnAndZoom();
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (enableDebugLogs) { Debug.Log("Time to spawn items."); }
            StartCoroutine(SpawnAndZoom());
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private IEnumerator SpawnAndZoom()
    {
        if (enableDebugLogs) { Debug.Log("Spawning items."); }

        if (tileGeneration.emptyTilePositions.Count == 0)
        {
            if (enableDebugLogs) { Debug.Log("No empty tile positions available."); }
            yield break;
        }

        if (enemy == null)
        {
            if (enableDebugLogs) { Debug.Log("Enemy prefab is not assigned."); }
            yield break;
        }

        int randomIndex = Random.Range(0, tileGeneration.emptyTilePositions.Count);
        Vector3Int position = tileGeneration.emptyTilePositions[randomIndex];

        Vector3 spawnPosition = new Vector3(position.x, position.y, 0);
        GameObject spawnedEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);

        if (enableDebugLogs) { Debug.Log("Spawned enemy at position: " + spawnPosition); }

        tileGeneration.emptyTilePositions.RemoveAt(randomIndex);

        // Zoom in on the spawned enemy
        yield return StartCoroutine(ZoomCamera(spawnedEnemy.transform));

        // Delay before zooming out
        yield return new WaitForSeconds(20f);

        // Zoom out after a delay
        yield return StartCoroutine(ZoomCameraOut());
    }

    private IEnumerator ZoomCamera(Transform target)
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float startTime = Time.time;
            float initialSize = mainCamera.orthographicSize;
            Vector3 initialPosition = mainCamera.transform.position;

            while (Time.time < startTime + zoomDuration)
            {
                float t = (Time.time - startTime) / zoomDuration;
                mainCamera.orthographicSize = Mathf.Lerp(initialSize, zoomedOutSize, t);
                mainCamera.transform.position = Vector3.Lerp(initialPosition, target.position, t);

                yield return null;
            }

            mainCamera.orthographicSize = zoomedOutSize;
        }
    }

    private IEnumerator ZoomCameraOut()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            float startTime = Time.time;
            float initialSize = mainCamera.orthographicSize;

            while (Time.time < startTime + zoomDuration)
            {
                float t = (Time.time - startTime) / zoomDuration;
                mainCamera.orthographicSize = Mathf.Lerp(initialSize, Camera.main.orthographicSize, t);

                yield return null;
            }

            mainCamera.orthographicSize = Camera.main.orthographicSize;
        }
    }
}
