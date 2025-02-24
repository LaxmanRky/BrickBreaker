using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f;
    private float paddleHalfWidth;
    private float screenBoundary;

    void Start()
    {
        // Get the paddle's width
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        paddleHalfWidth = spriteRenderer.bounds.size.x / 2;

        // Calculate screen boundaries in world coordinates
        screenBoundary = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Keep paddle within screen bounds, accounting for paddle width
        float xPos = Mathf.Clamp(transform.position.x, -screenBoundary + paddleHalfWidth, screenBoundary - paddleHalfWidth);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
