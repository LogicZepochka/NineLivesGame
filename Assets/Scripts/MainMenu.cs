using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsWindow;
    public void PlayGame()
    {
        SceneManager.LoadScene("StartLevel");
    }

    public void ExitGame()
    {
        Debug.Log("exit!");
        Application.Quit();
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
    }
}
