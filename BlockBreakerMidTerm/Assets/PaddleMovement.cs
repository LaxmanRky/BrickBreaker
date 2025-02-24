using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Keep paddle within screen bounds
        float xPos = Mathf.Clamp(transform.position.x, -7.5f, 7.5f);
        transform.position = new Vector3(xPos, transform.position.y, 0);
    }
}
