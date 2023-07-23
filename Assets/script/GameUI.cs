using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public void NextLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RetryLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
