using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoadManager : MonoBehaviour
{
    public float X, Y;
    private int levelId;
    public Transform player;

    private void Start()
    {
        player =transform;
        Load();
    }

    private void Update()
    {
        X = transform.position.x;
        Y = transform.position.y;
        levelId = SceneManager.GetActiveScene().buildIndex;
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("X", X);
        PlayerPrefs.SetFloat("Y", Y);
        PlayerPrefs.SetInt("levelId", levelId);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("X"))
        {
            X = PlayerPrefs.GetFloat("X");
        }
        if (PlayerPrefs.HasKey("Y"))
        {
            Y = PlayerPrefs.GetFloat("Y");
        }
        if (PlayerPrefs.HasKey("levelId"))
        {
            levelId = PlayerPrefs.GetInt("levelId");           
        }
       // SceneManager.LoadScene(levelId);
        player.transform.position = new Vector3(X, Y);
    }
}

