using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseWin : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject losePanel;

    public void Pause()
    {
        if (pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
        }
        else
        {
            pausePanel.SetActive(true);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
    }
}
