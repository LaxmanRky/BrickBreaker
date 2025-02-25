using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
