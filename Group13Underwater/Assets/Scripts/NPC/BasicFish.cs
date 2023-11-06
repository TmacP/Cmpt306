using UnityEngine;
using UnityEngine.Serialization;

public class BasicFish : MonoBehaviour
{
    private float moveSpeed = 5;
    [SerializeField] private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float changeDirectionTimer = 2f;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        timer = changeDirectionTimer;
        ChangeRandomDirection();
    }

    void FixedUpdate()
    {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 15, 7));
        timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            ChangeRandomDirection();
            timer = changeDirectionTimer;
        }
    }

    private void ChangeRandomDirection()
    {
        float randomDirectionX = Random.Range(-1f, 1f); // Random horizontal direction between -1 and 1
        rb.velocity = new Vector2(randomDirectionX, 0) * moveSpeed; // Move only horizontally

        // Flip the sprite based on the direction
        if (randomDirectionX > 0)
        {
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (randomDirectionX < 0)
        {
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
}
