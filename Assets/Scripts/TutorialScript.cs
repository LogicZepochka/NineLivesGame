using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private int pressECount = 0;
    [SerializeField] private GameObject tutorialWindow;
    [SerializeField] private GameObject levelComplitedPanel;
    private bool playerInTrigger = false;
    private bool isVisible= false;

    private void Update()
    {
        
        if (playerInTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pressECount++;
            }
        }

        if (!isVisible)
        {
            if (pressECount == 1 && !levelComplitedPanel.activeSelf)
            {
                StartCoroutine(DelayedAction());
            }
        }
    }

    private IEnumerator DelayedAction()
    {
        yield return new WaitForSeconds(5);
        tutorialWindow.SetActive(true);
        isVisible = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            pressECount = 0;
        }
    }
}
