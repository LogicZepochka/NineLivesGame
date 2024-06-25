using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToNextLevel : MonoBehaviour
{

    [SerializeField] private int LevelId;

    public GameObject LoadingScreen;
    public Slider slider;
    [SerializeField] private GameObject levelEndPanel;

 
    public void Loading()
    {        
        LoadingScreen.SetActive(true);
        if (levelEndPanel != null)
        {
            levelEndPanel.SetActive(false);
        }
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(LevelId);
        loadAsync.allowSceneActivation = false;

        while (!loadAsync.isDone)
        {
            slider.value = loadAsync.progress;

            if (loadAsync.progress >= .9f && !loadAsync.allowSceneActivation )
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation=true;
            }
            yield return null;
        }
    }

}
