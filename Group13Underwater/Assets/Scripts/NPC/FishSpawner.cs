using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static UnityEngine.Random;

public class FishSpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	[SerializeField] private float spawnRate = 2.0f;
	[SerializeField] private float spawnRadius = 6f;
	private float maxVar = 0.05f;
	//[SerializeField] private Transform[] spawnPoints;
	private float spawnTimer;
	private int numberOfEnemiesSpawned = 0;

	
   // Update is called once per frame
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.05f, spawnRate);
    }


	private void SpawnEnemy(){
		
		if(Time.time >spawnTimer){
			Vector3 playerPosition = GameManager.instance.player.transform.position;
			float randomAngle = Random.Range(0, 2 * Mathf.PI);
			 Vector3 randomSpawnOffset = new Vector3(
                spawnRadius * Mathf.Cos(randomAngle),
                0,
                spawnRadius * Mathf.Sin(randomAngle)
            );
			Vector3 randomSpawnPosition = playerPosition + randomSpawnOffset;
			GameObject newEnemy = Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
			numberOfEnemiesSpawned++;
			spawnTimer=Time.time+spawnRate+Random.Range(-maxVar,maxVar);
		}

}
}


