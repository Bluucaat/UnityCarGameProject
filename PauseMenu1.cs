using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu1 : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] GameObject pauseMenu;
    private AudioSource audioSource;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame(); 
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        audioSource.Pause();
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 3f;
        isPaused = false;
        audioSource.UnPause();
        
    }
    public void ReturnToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        isPaused = false;

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
