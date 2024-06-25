using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerPositionSaver : MonoBehaviour
{
    private string playerPosXKey = "X";
    private string playerPosYKey = "Y";
    private string levelId = "levelId";

    private string fishFoodX = "fishFoodX";
    private string fishFoodY = "fishFoodY";

    private string meatFoodX = "meatFoodX";
    private string meatFoodY = "meatFoodY";

    private string chikenFoodX = "chikenFoodX";
    private string chikenFoodY = "chikenFoodY";

    private string freshGetFood = "freshGetFood";

    private string luna1 = "luna1Active";
    private string luna2Text = "luna2Text";


    private GameObject player;
    private GameObject fish;
    private GameObject meat;
    private GameObject chiken;
    private GameObject fishFoodShow;
    public Button ContinueGameButton;

    private GameObject LunaNPC1;
    private GameObject LunaNPC2;
    Quest lunaQuest;


    private void Start()
    {
        player = GameObject.Find("Player");       

        if (SceneManager.GetActiveScene().buildIndex == 0 || PlayerPrefs.GetInt(levelId) == 0)
        {
            if (ContinueGameButton != null)
            {
                if (!PlayerPrefs.HasKey(levelId) || PlayerPrefs.GetInt(levelId) == 0)
                {
                    ContinueGameButton.interactable = false;
                }
                else
                {
                    ContinueGameButton.interactable = true;
                }
            }
           
        }

        if (player != null && SceneManager.GetActiveScene().buildIndex > 0)
        {
            LoadPlayerPosition();
        }      
        if ( SceneManager.GetActiveScene().buildIndex == 2)
        {
            fish = GameObject.Find("fishFood");
            meat = GameObject.Find("meatFood");
            chiken = GameObject.Find("chikenFood");
            fishFoodShow = GameObject.Find("fishFoodShow");
            fishFoodShow.SetActive(false);
            LoadFood();
        }
        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            LunaNPC1 = GameObject.Find("LunaNPC1");
            LunaNPC2 = GameObject.Find("QuestLuna");
            lunaQuest = LunaNPC2.GetComponent<Quest>();
            LoadLunas();
        }
    }

    public void LoadLunas()
    {
        if (PlayerPrefs.HasKey(luna1) && PlayerPrefs.HasKey(luna2Text))
        {
            LunaNPC1.SetActive(Convert.ToBoolean(PlayerPrefs.GetString(luna1)));
        }
    }

    public void SaveLunas()
    {
        PlayerPrefs.SetString(luna1, LunaNPC1.activeSelf.ToString());
        if (lunaQuest != null && lunaQuest.questNumber == 3)
        {
            PlayerPrefs.SetString(luna2Text, "True");
        }
        else { PlayerPrefs.SetString(luna2Text, "False"); }
        PlayerPrefs.Save();
    }

    public void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat(playerPosXKey, player.transform.position.x);
        PlayerPrefs.SetFloat(playerPosYKey, player.transform.position.y);
        PlayerPrefs.Save();

    }

    public void ResetLunas()
    {
        PlayerPrefs.SetString(luna1, "True");
        PlayerPrefs.SetString(luna2Text, "False");
        PlayerPrefs.Save();
    }

    public void ResetPlayerPosition()
    {
       
        PlayerPrefs.SetFloat(playerPosXKey, -43.6f);
        PlayerPrefs.SetFloat(playerPosYKey, 10.17f);

        PlayerPrefs.Save();

    }

    public void ResetPlayerPositionForSecondLevel()
    {
        PlayerPrefs.SetFloat(playerPosXKey, -61.85f);
        PlayerPrefs.SetFloat(playerPosYKey, 9.7f);

        PlayerPrefs.Save();

    }

    public void ResetPlayerPositionForThirdLevel()
    {
        PlayerPrefs.SetFloat(playerPosXKey, -11.1f);
        PlayerPrefs.SetFloat(playerPosYKey, -36.6f);

        PlayerPrefs.Save();

    }

    public void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ResetFood()
    {
        PlayerPrefs.SetFloat(fishFoodX, 53.8f);
        PlayerPrefs.SetFloat(fishFoodY, 28.4f);
        PlayerPrefs.SetString(freshGetFood, "false");

        PlayerPrefs.SetFloat(meatFoodX, -25.2f);
        PlayerPrefs.SetFloat(meatFoodY, 29.1f);

        PlayerPrefs.SetFloat(chikenFoodX, -25.5f);
        PlayerPrefs.SetFloat(chikenFoodY, -25.7f);

        PlayerPrefs.Save();

    }

    public void ResetNotAllFood()
    {
        PlayerPrefs.SetFloat(meatFoodX, -25.2f);
        PlayerPrefs.SetFloat(meatFoodY, 29.1f);

        PlayerPrefs.SetFloat(chikenFoodX, -25.5f);
        PlayerPrefs.SetFloat(chikenFoodY, -25.7f);

        PlayerPrefs.Save();

    }

    public void SaveLevelId()
    {
        PlayerPrefs.SetInt(levelId, SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }

    public void SaveFood()
    {      

        if (fish != null)
        {
            PlayerPrefs.SetFloat(fishFoodX, fish.transform.position.x);
            PlayerPrefs.SetFloat(fishFoodY, fish.transform.position.y);
            PlayerPrefs.SetString(freshGetFood, "false");
        }
        else
        {
            if (fishFoodShow.activeSelf == true)
            {
                PlayerPrefs.SetString(freshGetFood, "true");
            }
        }

        PlayerPrefs.SetFloat(meatFoodX, -25.2f);
        PlayerPrefs.SetFloat(meatFoodY, 29.1f);

        PlayerPrefs.SetFloat(chikenFoodX, -25.5f);
        PlayerPrefs.SetFloat(chikenFoodY, -25.7f);

        PlayerPrefs.Save();
    }

    public void LoadFood()
    {       
        if (PlayerPrefs.HasKey(meatFoodX) && PlayerPrefs.HasKey(meatFoodY) && PlayerPrefs.HasKey(chikenFoodX) && PlayerPrefs.HasKey(chikenFoodY))
        {
            ResetNotAllFood();
        }
        
        if (PlayerPrefs.HasKey(freshGetFood) && PlayerPrefs.GetString(freshGetFood) == "false")
        {
            PlayerPrefs.SetFloat(fishFoodX, 53.8f);
            PlayerPrefs.SetFloat(fishFoodY, 28.4f);
        }
        else
        {
            Destroy(fish);
            fishFoodShow.SetActive(true);           
        }
    }

    public void ResetLevelId()
    {
        PlayerPrefs.SetInt(levelId, 0);
    }


    public void LoadLevelId()
    {
        if (PlayerPrefs.HasKey(levelId))
        {
            int level = PlayerPrefs.GetInt(levelId);
            if (level > 0 )
            {
                SceneManager.LoadScene(level);
            }           
        }
        else { ResetLevelId(); }
    }

    public void LoadPlayerPosition()
    {
        if (PlayerPrefs.HasKey(playerPosXKey) && PlayerPrefs.HasKey(playerPosYKey))
        {
            float posX = PlayerPrefs.GetFloat(playerPosXKey);
            float posY = PlayerPrefs.GetFloat(playerPosYKey);
            player.transform.position = new Vector3(posX, posY, 0);

            Debug.Log("Player position loaded.");
        }
        else
        {
            ResetPlayerPosition();
        }
    }
}
