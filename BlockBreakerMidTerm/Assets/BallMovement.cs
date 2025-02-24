using UnityEngine;

public class Ball : MonoBehaviour
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
        rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            float x = (transform.position.x - collision.transform.position.x) * 2;
            rb.velocity = new Vector2(x, rb.velocity.y).normalized * speed;
        }
    }
}
