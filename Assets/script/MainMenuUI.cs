using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button closeHelpPanelButton;

    [SerializeField] private GameObject helpPanel;

    private bool isActive = false;
    private const string LEVEL_1 = "Level1";

    private void Start()
    {
        exitButton.onClick.AddListener(QuitGame);
        playButton.onClick.AddListener(StartGame);
        helpButton.onClick.AddListener(ToggleHelpPanel);
        closeHelpPanelButton.onClick.AddListener(ToggleHelpPanel);
    }

    private void StartGame()
    {
        SceneManager.LoadScene(LEVEL_1);
    }

    private void ToggleHelpPanel()
    {
        isActive = !isActive;
        helpPanel.SetActive(isActive);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
