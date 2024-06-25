using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class DialogMethods : MonoBehaviour
{
    private DialogeWindow _dialogWindow;
    private float _cooldownNewLetter = 0.05f;


    private DialogeChoice _dialogChoice;
    public bool CanContinueToNextLine { get; private set; }
    private Coroutine _displayLineCoroutine;
    [SerializeField] private GameObject goNext;

    public void ExitForGame()
    {
        Application.Quit();
    }



    public void AllKeys()
    {
        _dialogWindow = FindObjectOfType<DialogeWindow>();
        string goodLine = "<color=#aa7960>Отлично, можешь идти дальше</color>";
        string badLine = "<color=#aa7960>Я не увидел трёх ключей...</color>";
        GameObject npc = GameObject.Find("NPCKeys");
        Quest quest = npc.GetComponent<Quest>();
        if (quest.questNumber == 3)
        {
            quest.barrier.SetActive(false);
            _displayLineCoroutine = StartCoroutine(DisplayLine(goodLine));
            //_dialogWindow.SetText(goodLine);
        }
        else
        {
            _displayLineCoroutine = StartCoroutine(DisplayLine(badLine));
            // _dialogWindow.SetText(badLine);
        }
    }

    public void DoorOpen()
    {
        _dialogWindow = FindObjectOfType<DialogeWindow>();
        string goodLine = "Отлично! Ключ подошел!";
        string badLine = "Наверное, стоит поискать ключ...";
        GameObject npc = GameObject.Find("DoorQuest");
        Quest quest = npc.GetComponent<Quest>();
        if (quest.questNumber == 1)
        {
            _displayLineCoroutine = StartCoroutine(DisplayLine(goodLine));
            npc.SetActive(false);
            goNext.SetActive(true);            
        }
        else
        {
            _displayLineCoroutine = StartCoroutine(DisplayLine(badLine));
            
        }
    }

    public IEnumerator DisplayLine(string line)
    {

        _dialogWindow.ClearText();

        //_dialogChoice.HideChoices();

        CanContinueToNextLine = false;
        bool isAddingRichText = false;
        string accumulatedText = "";

        yield return new WaitForSeconds(0.000f);

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetMouseButtonDown(0))
            {
                _dialogWindow.SetText(line);
                break;
            }

            isAddingRichText = letter == '<' || isAddingRichText;

            if (letter == '>')
            {
                isAddingRichText = false;
            }

            accumulatedText += letter;
            _dialogWindow.SetText(accumulatedText);

            if (isAddingRichText == false)
            {
                yield return new WaitForSeconds(_cooldownNewLetter);
            }
        }
    }
}
