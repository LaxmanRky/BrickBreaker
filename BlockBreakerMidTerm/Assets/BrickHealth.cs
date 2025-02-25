using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickHealth : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int totalBricks;

    public AudioClip brickDestroyed;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Debug.Log($"Initial brick color: {spriteRenderer.color}");

        totalBricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    bool IsRedBrick(Color color)
    {
        return color.r > 0.9f && color.g < 0.2f && color.b < 0.2f;
    }

    bool IsGreenBrick(Color color)
    {
        // The green bricks in your game have RGB values around (0.118, 0.533, 0.000)
        return color.g > 0.5f && color.r < 0.2f && color.b < 0.2f;
    }

    bool IsWhiteBrick(Color color)
    {
        return color.r > 0.9f && color.g > 0.9f && color.b > 0.9f;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a BallMovement component
        if (collision.gameObject.GetComponent<BallMovement>() != null)
        {
            Color currentColor = spriteRenderer.color;
            Debug.Log($"Ball hit brick! Current color: {currentColor}");
            
            if (IsRedBrick(currentColor))
            {
                // Red brick turns green
                spriteRenderer.color = new Color(0.118f, 0.533f, 0f); // Set to exact green color
                Debug.Log("Red brick turned green");
            }
            else if (IsGreenBrick(currentColor))
            {
                // Green brick turns white
                spriteRenderer.color = Color.white;
                Debug.Log("Green brick turned white");
            }
            else if (IsWhiteBrick(currentColor))
            {
                // White brick vanishes
                Debug.Log("White brick destroyed");
                totalBricks --;

                if(totalBricks <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }

                AudioSource.PlayClipAtPoint(brickDestroyed, transform.position);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log($"Unknown brick color: {currentColor}");
            }
        }
    }
}
