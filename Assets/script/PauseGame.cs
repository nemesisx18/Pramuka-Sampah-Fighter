using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button restartButton;

    [SerializeField] private GameObject pausePanel;

    private bool isPaused = false;

    private void Start()
    {
        menuButton.onClick.AddListener(ReturnMenu);
        pauseButton.onClick.AddListener(TogglePause);
        resumeButton.onClick.AddListener(TogglePause);
        restartButton.onClick.AddListener(RestartLevel);
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        pausePanel.SetActive(isPaused);
    }

    private void RestartLevel()
    {
        string currentLevel = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentLevel);
    }

    private void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}