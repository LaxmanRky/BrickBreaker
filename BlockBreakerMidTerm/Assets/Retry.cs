using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour
{
     public AudioClip gameOver;

    void Start()
    {

       AudioSource.PlayClipAtPoint(gameOver, Vector2.zero);

    }
    public void RetryButton()
    {
        SceneManager.LoadScene("GameScene");

    }
  
}
