using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    public GameObject settingsWindow;
    public GameObject dialogWindow;


    private void Update()
    {
        dialogWindow = GameObject.Find("DialogWindow");
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (dialogWindow == null)
            {
                if (PauseGame)
                {
                    if (!settingsWindow.activeSelf)
                    {
                        Resume();
                    }
                   
                }
                else
                {
                    Pause();
                }
            }
           
        }
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        settingsWindow.SetActive(true);
    }
}
