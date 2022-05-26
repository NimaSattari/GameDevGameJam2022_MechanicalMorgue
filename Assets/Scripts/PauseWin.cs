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
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
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
        Camera camera = Camera.main;
        StartCoroutine(camera.GetComponent<CameraShake>().Shake(0.5f, 0.5f));
        FindObjectOfType<MusicPlayer>().PlayLose();
        losePanel.SetActive(true);
    }
}
