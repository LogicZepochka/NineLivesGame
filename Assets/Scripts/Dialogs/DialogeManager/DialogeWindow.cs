using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(DialogeChoice))]
public class DialogeWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayName;
    [SerializeField] private TextMeshProUGUI _displayText;
    [SerializeField] private GameObject _dialogWindow;
    [SerializeField, Range(0f,20f)] private float _cooldownNewLetter = 0.05f;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private GameObject inventoryWindow;

    

    private DialogeChoice _dialogChoice;

    public bool IsStatusAnswer {  get; private set; }
    public bool IsPlaying {  get; private set; }
    public bool CanContinueToNextLine {  get; private set; }

    public float CoolDownNewLetter
    {
        get => _cooldownNewLetter;
        private set 
        {
            _cooldownNewLetter = 0.5f;
        }
    }

    private float CheckCooldown (float value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Значение задержки между буквами было отрицательным");
        }
        return value;
    }

   

    public void Init()
    {
        IsStatusAnswer = false;
        CanContinueToNextLine = false;

        _dialogChoice = GetComponent<DialogeChoice>();
        _dialogChoice.Init();
    }

    public void SetActive(bool active)
    {
        IsPlaying = active;
        _dialogWindow.SetActive(active);
        inventoryWindow.SetActive(!active);
    }
 

    public void SetText(string text)
    {
        _displayText.text = text;
    }

    public void Add(string text)
    {
        _displayText.text += text;
    }

    public void Add(char letter)
    {
        _displayText.text += letter;
    }

    public void SetPortraits(string tagValue)
    {
        portraitAnimator.Play(tagValue);       
    }

    public void ClearText()
    {
        SetText(string.Empty);
    }

    public void SetName(string namePerson)
    {
        _displayName.text = namePerson;
    }


    public void SetCooldown(float cooldown)
    {
        CoolDownNewLetter = 0.3f;
    }

    public void MakeChoice()
    {
        if (CanContinueToNextLine == false)
        {
            return;
        }
        IsStatusAnswer = false;
    }


    public IEnumerator DisplayLine(Story story)
    {
        string line = story.Continue();

        ClearText();

        _dialogChoice.HideChoices();

        CanContinueToNextLine = false;
        bool isAddingRichText = false;

        yield return new WaitForSeconds(0.000f);

        foreach (char letter in line.ToCharArray())
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetText(line);
                break;
            }

            isAddingRichText = letter == '<' || isAddingRichText;

            if (letter == '>')
            {
                isAddingRichText = false;
            }

            Add(letter);

            if (isAddingRichText == false)
            {
                yield return new WaitForSeconds(_cooldownNewLetter);
            }
        }
        CanContinueToNextLine = true;
        IsStatusAnswer = _dialogChoice.DisplayChoices(story);
    }

    
}
