using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTointerract : MonoBehaviour
{
    public bool playerIsClose { get; set; }
    public GameObject press;
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

    public bool PlayerIsClose()
    {
        return playerIsClose;
    }
}
