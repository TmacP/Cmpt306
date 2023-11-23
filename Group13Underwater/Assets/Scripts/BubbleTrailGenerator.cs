using UnityEngine;

public class BubbleTrailGenerator : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float interval = 0.2f;

    private float timer = 0f;

    void Update()
    {
        // Spawn a new bubble prefab at regular intervals
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Instantiate(bubblePrefab, transform.position, Quaternion.identity);
            timer = interval;
        }
    }
}
