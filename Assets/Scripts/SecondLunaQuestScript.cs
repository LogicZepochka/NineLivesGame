using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLunaQuestScript : MonoBehaviour
{
    GameObject QuestLuna;
    Quest lunaQuest;
    GameObject NPCLuna;

    public TextAsset doneDialog;
    public TextAsset badDialog;
    private bool isPlayerInTrigger = false;
    NPCTrigger script;
    private GameObject nextLevel;

    private void Start()
    {
        QuestLuna = GameObject.Find("QuestLuna");
        lunaQuest = QuestLuna.GetComponent<Quest>();
        NPCLuna = GameObject.Find("LunaNPC2");
        script = NPCLuna.GetComponent<NPCTrigger>();
        nextLevel = GameObject.Find("NextLevel");

        if (PlayerPrefs.HasKey("luna2Text"))
        {
            if (PlayerPrefs.GetString("luna2Text") != "False")
            {
                script.ChangeDialog(doneDialog);
                nextLevel.SetActive(true);
            }
            else
            {
                nextLevel.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (lunaQuest != null)
        {
            if (lunaQuest.questNumber == 3)
            {
                script.ChangeDialog(doneDialog);
                nextLevel.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
}
