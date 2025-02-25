using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
 public BallMovement ball;
 public AudioClip gameOver;


 public void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.CompareTag("Ball"))
     {
        AudioSource.PlayClipAtPoint(gameOver, transform.position);
         SceneManager.LoadScene("GameOver");
     }
 }
}
