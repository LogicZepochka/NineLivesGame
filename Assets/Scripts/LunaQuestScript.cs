using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaQuestScript : MonoBehaviour
{
    int ENums = 0;
    GameObject luna1;
    GameObject luna2;
    private bool isPlayerInTrigger = false;
    private void Start()
    {
        luna1 = GameObject.Find("LunaNPC1");
        luna2 = GameObject.Find("LunaNPC2");
    }

    private void OnBecameInvisible()
    {
        if (ENums > 0)
        {
            luna2.SetActive(true);
            luna1 .SetActive(false);           
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPlayerInTrigger)
            {
                ENums++;
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
