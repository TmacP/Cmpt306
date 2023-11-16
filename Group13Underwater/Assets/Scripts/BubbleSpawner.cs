using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    [SerializeField] GameObject bubblePrefab;

    void Start()
    {
        StartCoroutine(BubbleSpawnLoop());
    }

    private IEnumerator BubbleSpawnLoop() {
        Vector3 pos = GameManager.instance.GetPlayerPosition();
        pos.y -= 90;
        Instantiate(bubblePrefab, pos, new Quaternion());
        yield return new WaitForSeconds(10);
        StartCoroutine(BubbleSpawnLoop());
    }
}
