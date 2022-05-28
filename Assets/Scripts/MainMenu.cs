using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string gameScene;
    [SerializeField] GameObject helpPanel;
    [SerializeField] GameObject levelPanel;
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    public void LoadLevel(string lelvel)
    {
        SceneManager.LoadScene(lelvel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Help()
    {
        if (helpPanel.activeInHierarchy)
        {
            helpPanel.SetActive(false);
        }
        else
        {
            helpPanel.SetActive(true);
        }
    }
    public void Levels()
    {
        if (levelPanel.activeInHierarchy)
        {
            levelPanel.SetActive(false);
        }
        else
        {
            levelPanel.SetActive(true);
        }
    }
}
