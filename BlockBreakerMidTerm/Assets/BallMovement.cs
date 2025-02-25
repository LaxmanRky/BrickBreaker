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
        // Start the ball with a random direction but keep it upwards initially
        Vector2 initialDirection = new Vector2(Random.Range(-1f, 1f), 1).normalized;
        rb.linearVelocity = initialDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Play collision sound
        AudioSource.PlayClipAtPoint(ballCollide, Vector3.zero);

        // Check if the ball collides with the paddle
        PaddleMovement paddle = collision.gameObject.GetComponent<PaddleMovement>();
        if (paddle != null)
        {
            // Reflect the ball's velocity based on where it hits the paddle
            float x = (transform.position.x - collision.transform.position.x) * 2f;
            rb.linearVelocity = new Vector2(x, 1).normalized * speed;
        }
        else
        {
            // Add a small random tweak to prevent infinite loops
            Vector2 newVelocity = rb.linearVelocity;
            float tweak = Random.Range(-0.1f, 0.1f); // Small random angle tweak
            newVelocity.x += tweak;
            newVelocity = newVelocity.normalized * speed;
            rb.linearVelocity = newVelocity;

            // Ensure the ball maintains a minimum bounce angle
            MaintainMinimumBounceAngle();
        }
    }

    void MaintainMinimumBounceAngle()
    {
        // Get the angle of the current ball trajectory
        float angle = Vector2.Angle(rb.linearVelocity, Vector2.up);

        // If the ball is too vertical or too horizontal, adjust its angle
        if (angle < minBounceAngle || angle > (180 - minBounceAngle))
        {
            // Apply a slight angle adjustment to avoid the ball going flat or too steep
            Vector2 adjustedVelocity = Quaternion.Euler(0, 0, minBounceAngle) * rb.linearVelocity;
            rb.linearVelocity = adjustedVelocity.normalized * speed;
        }
    }
}
