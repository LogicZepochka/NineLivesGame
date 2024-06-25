using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplited : MonoBehaviour
{
    public bool playerIsClose = false;
    private ButtonTointerract interract;
    [SerializeField] private GameObject LevelCompletedCanvas;
    private void Start()
    {
        interract = GetComponent<ButtonTointerract>();
    }

    private void Update()
    {
        if (interract != null) // Добавьте проверку на null перед использованием b
        {
            playerIsClose = interract.PlayerIsClose();

            if (playerIsClose && Input.GetKeyDown(KeyCode.E))
            {
                GameObject[] inventory = GameObject.FindGameObjectsWithTag("Inventory");
                LevelCompletedCanvas.SetActive(true);
                foreach (GameObject item in inventory)
                {
                    item.SetActive(false);
                }
                
            }
        }
    }
}
