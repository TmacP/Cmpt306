using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishEnemyPrefab;
    public Transform playerTransform;
    public float spawnRadius = 10f;
    public int maxEnemies = 20;
    public float spawnInterval = 8f;

    private int currentEnemyCount = 0;
    private bool enableSpawning = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enableSpawning && currentEnemyCount < maxEnemies)
        {
            Vector3 randomSpawnPoint = GetRandomSpawnPoint();
            Instantiate(fishEnemyPrefab, randomSpawnPoint, Quaternion.identity);
            currentEnemyCount++;

            yield return new WaitForSeconds(spawnInterval);
        }
        StopSpawning();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPoint = new Vector3(randomCircle.x, 0f, randomCircle.y) + playerTransform.position;
        spawnPoint.y = 0f; // Ensure enemies spawn at ground level 

        return spawnPoint;
    }

    public void StopSpawning()
    {
        enableSpawning = false;
    }
}
