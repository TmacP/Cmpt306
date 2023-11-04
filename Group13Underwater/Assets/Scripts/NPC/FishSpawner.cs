using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Enemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

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
            Instantiate(Enemy, new Vector3(xPos,-4,zPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            EnemyCount+=1;
        }
        
    }
}
