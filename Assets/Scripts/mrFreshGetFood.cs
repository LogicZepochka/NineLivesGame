using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class mrFreshGetFood : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToShow;
    public TextAsset doneDialog;
    public TextAsset badDialog;
    private GameObject nextLevel;
    private bool isGettedFood = false;
    NPCTrigger script;

    private void Start()
    {
        nextLevel = GameObject.Find("NextLevel");
        GameObject fish = GameObject.Find("fishFood");
        GameObject npcFresh = GameObject.Find("MrFreshNPC");
        script = npcFresh.GetComponent<NPCTrigger>();
        if (PlayerPrefs.HasKey("freshGetFood") && PlayerPrefs.GetString("freshGetFood") == "true")
        {
            script.ChangeDialog(doneDialog);
            nextLevel.SetActive(true);
        }
        else
        {
            nextLevel.SetActive(false);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject obj = GameObject.Find("fishFoodShow");       
       
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (other.gameObject == objectToDestroy)
        {          
            Destroy(objectToDestroy);

            if (objectToShow != null)
            {
                objectToShow.SetActive(true);

                if (doneDialog != null)
                {
                    script.ChangeDialog(doneDialog);
                    isGettedFood = true;
                    nextLevel.SetActive(true);
                }
            }
        }
        else if (other.gameObject != objectToDestroy && other.gameObject != playerObject && isGettedFood == false)
        {
            script.ChangeDialog(badDialog);
        }
    }
}
