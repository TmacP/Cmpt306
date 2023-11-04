using UnityEngine;

public class BasicFish : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 50;
    [SerializeField] private float maxHorizontalAngle = 30f;
    [SerializeField] private float changeDirectionTimer = 2f;
    [SerializeField] private bool enableDebugLogs = true;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector3 currentDirection = Vector3.zero;
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
        RotateFish();
        timer -= Time.fixedDeltaTime;

        if (timer <= 0f)
        {
            ChangeRandomDirection();
            timer = changeDirectionTimer;
        }
    }

    void RotateFish()
    {
        // Code for fish movement/animation (tilting)
        transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 15, 7));
    }

private void ChangeRandomDirection()
{
    float randomX = Random.Range(-1f, 1f); // Random value between -1 and 1
    Vector3 randomDirection = new Vector3(randomX, 0, 0);

    // Ensure the random direction is not zero
    while (randomDirection == Vector3.zero)
    {
        randomX = Random.Range(-1f, 1f);
        randomDirection = new Vector3(randomX, 0, 0);
    }

    rb.AddForce(randomDirection * moveSpeed);

    if (currentDirection != randomDirection)
    {
        if (randomDirection.x > 0)
        {
            if (!spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
        }
        else if (randomDirection.x < 0)
        {
            if (spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            }
        }

        currentDirection = randomDirection;
    }



        // Instead of directly adding force here, you can add your logic for changing direction.
        // If you want to add force to move the fish in this method, you can do that.
    }
}
