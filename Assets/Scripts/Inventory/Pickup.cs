using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject slotButton;
    public bool playerIsClose;
    public GameObject press;
    public int id;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void Update()
    {
        if (playerIsClose == true && Input.GetKeyDown(KeyCode.E))
        {

            for (int j = 0; j < inventory.slots.Length; j++)
            {
                if (inventory.isFull[j] == false)
                {
                    Destroy(gameObject);
                    Instantiate(slotButton, inventory.slots[j].transform);
                    inventory.isFull[j] = true;

                    break;
                }
            }



        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            press.SetActive(true);
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            press.SetActive(false);
            playerIsClose = false;

        }
    }
}
