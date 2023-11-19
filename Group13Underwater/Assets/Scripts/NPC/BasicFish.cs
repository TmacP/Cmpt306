using UnityEngine;
using UnityEngine.Serialization;

public class BasicFish : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private int tiltSpeed = 15; // The standard speed of our tilt 
    [SerializeField] private int tiltDepth = 7; // The standard depth/degree of our tilt
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
        // OG: 15, 7
        // Slower Longer, 15, 20
        // Quicker: 25, 7
        // Really quick: 35, 10 ?
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * tiltSpeed, tiltDepth));
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
