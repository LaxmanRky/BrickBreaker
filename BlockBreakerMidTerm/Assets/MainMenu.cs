using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f; 
        audioSource.Play();

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
