using UnityEngine;

public class Brick : MonoBehaviour
{
    [Header("Brick Settings")]
    [Tooltip("Set hit points: 1 (White), 2 (Green), 3 (Red)")]
    public int hitPoints = 1;

    [Tooltip("Assign colors in order: White, Green, Red")]
    public Color[] colors;  // [0] = White, [1] = Green, [2] = Red

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (sr == null)
        {
            Debug.LogError("No SpriteRenderer found on Brick!");
            return;
        }

        UpdateColor();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitPoints--;

            if (hitPoints <= 0)
            {
                Destroy(gameObject);  // Destroy the brick when hit points reach 0
            }
            else
            {
                UpdateColor();  // Change to the next color based on hitPoints
            }
        }
    }

    void UpdateColor()
    {
        // Ensure the colors array has enough colors
        if (colors != null && colors.Length >= 3)
        {
            // Use hitPoints to determine color: 3 -> Red, 2 -> Green, 1 -> White
            sr.color = colors[hitPoints - 1];
        }
        else
        {
            Debug.LogWarning("Colors array is missing or incomplete.");
        }
    }
}
