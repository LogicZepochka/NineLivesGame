using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questNumber = 1;
    public int[] items;
    public GameObject barrier;

    private bool canInteract = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!canInteract) return; // ���� ������ �����������������, �������

        if (other != null && other.tag != "Player")
        {
            Pickup pickupComponent = other.gameObject.GetComponent<Pickup>();
            if (pickupComponent != null && questNumber < items.Length && pickupComponent.id == items[questNumber])
            {
                questNumber++;
                canInteract = false; // ��������� ��������������
                StartCoroutine(EnableInteract()); // ��������� �������� ��� ������������� ��������������

                Destroy(other.gameObject);
                //CheckQuest();
            }
        }
    }

    private IEnumerator EnableInteract()
    {
        yield return new WaitForSeconds(0.5f); // ��������� ��������, ����� �������� �������� �� �������������
        canInteract = true; // ��������� �������������� �����
    }

}
