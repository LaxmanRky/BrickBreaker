using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    public float minBounceAngle = 15f; // Minimum angle to prevent stalling

    public AudioClip ballCollide;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        Vector2 initialDirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.linearVelocity = initialDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play collision sound
        AudioSource.PlayClipAtPoint(ballCollide, Vector3.zero);

        // Check if colliding with Paddle
        PaddleMovement paddle = collision.gameObject.GetComponent<PaddleMovement>();
        if (paddle != null)
        {
            // Reflect based on hit position on the paddle
            float x = (transform.position.x - collision.transform.position.x) * 2f;
            rb.linearVelocity = new Vector2(x, 1).normalized * speed;
        }
        else
        {
            // Add small random tweak to prevent infinite loops
            Vector2 newVelocity = rb.linearVelocity;
            float tweak = Random.Range(-0.1f, 0.1f);
            newVelocity.x += tweak;
            newVelocity = newVelocity.normalized * speed;
            rb.linearVelocity = newVelocity;

            // Apply minimum bounce angle correction
            MaintainMinimumBounceAngle();
        }
    }

    void MaintainMinimumBounceAngle()
    {
        float angle = Vector2.Angle(rb.linearVelocity, Vector2.up);

        // Check if the angle is too vertical or too horizontal
        if (angle < minBounceAngle || angle > (180 - minBounceAngle))
        {
            // Apply slight adjustment to keep the ball moving
            Vector2 adjustedVelocity = Quaternion.Euler(0, 0, minBounceAngle) * rb.linearVelocity;
            rb.linearVelocity = adjustedVelocity.normalized * speed;
        }
    }
}
