using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a PaddleMovement component
        PaddleMovement paddle = collision.gameObject.GetComponent<PaddleMovement>();
        if (paddle != null)
        {
            float x = (transform.position.x - collision.transform.position.x) * 2;
            rb.linearVelocity = new Vector2(x, rb.linearVelocity.y).normalized * speed;
        }
    }
}
