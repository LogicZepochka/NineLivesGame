using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int id;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    public void DropItem()
    {
        inventory.isFull[id] = false;
        if (transform.childCount > 0)
        {
            transform.GetChild(0).GetComponent<Spawn>().SpawnDroppedItem();
        }
    }
}
