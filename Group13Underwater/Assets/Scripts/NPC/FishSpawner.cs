using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;
    public float terrainHeightOffset = 2f;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount<20){
            xPos = Random.Range(-16,13);
            zPos = Random.Range(-20,1);
            
            // Raycast to find the terrain height at the spawn point
            RaycastHit hit;

            Vector3 raycastOrigin = new Vector3(xPos, 100f, zPos); // Cast ray from above to find terrain
            if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("TileMap")))
            {  float yPosition = hit.point.y + terrainHeightOffset;
                Vector3 spawnPosition = new Vector3(xPos, yPosition, zPos);
                Instantiate(Enemy, spawnPosition, Quaternion.identity);

            //Instantiate(Enemy, new Vector3(xPos,-4,zPos), Quaternion.identity);
            }
             yield return new WaitForSeconds(8);
            EnemyCount+=1;

        }
        
    }
}