using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;

    private void Awake()
    {
        if(isFull.Length != slots.Length) // ������� ��� ���������� ������
        {
            Debug.LogError("Slots lenght is not equal isFull lenght!");
        }
    }
}
