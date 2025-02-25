using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
 public BallMovement ball;

 public void OnTriggerEnter2D(Collider2D collision)
 {
     if (collision.CompareTag("Ball"))
     {
         SceneManager.LoadScene("MainMenu");
     }
 }
}
