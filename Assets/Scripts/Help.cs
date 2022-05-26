using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject helpPanel;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void HideHelp()
    {
        helpPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
