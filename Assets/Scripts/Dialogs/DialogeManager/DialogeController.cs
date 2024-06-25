using Ink.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogeWindow), typeof(DialogeTag))]
public class DialogeController : MonoBehaviour
{
    private DialogeWindow _dialogeWindow;
    private DialogeTag _dialogeTag;

    public Story CurrentStory { get; private set; }
    private Coroutine _displayLineCoroutine;

    AudioSource _audioSource;

    private void Awake()
    {
        _dialogeTag = GetComponent<DialogeTag>();
        _dialogeWindow = GetComponent<DialogeWindow>();

        _dialogeTag.Init();
        _dialogeWindow.Init();
    }

    private void Start()
    {
        _dialogeWindow.SetActive(false);
    }

    private void Update()
    {
        if(_dialogeWindow.IsStatusAnswer == true || _dialogeWindow.IsPlaying == false || _dialogeWindow.CanContinueToNextLine == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
            ContinueStory();
        }
    }

    public void EnterDialogMode(TextAsset inkJSON)
    {
        CurrentStory = new Story(inkJSON.text);

        _dialogeWindow.SetActive(true);       

        ContinueStory();
    }

    public void EnterDialogMode(TextAsset inkJSON, AudioSource audio)
    {
        CurrentStory = new Story(inkJSON.text);

        _dialogeWindow.SetActive(true);

        ContinueStory(audio);
        
    }

    private IEnumerator ExitDialogMode()
    {
        yield return new WaitForSeconds(_dialogeWindow.CoolDownNewLetter);

        _dialogeWindow.SetActive(false);

        _dialogeWindow.ClearText();
    }

    private void ContinueStory(AudioSource audio)
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialogMode());
            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }
        _displayLineCoroutine = StartCoroutine(_dialogeWindow.DisplayLine(CurrentStory));

        if (audio != null)
        {
            audio.Play();
        }

        try
        {
            _dialogeTag.HandleTags(CurrentStory.currentTags);
        }
        catch(ArgumentException ex)
        {
            Debug.Log(ex);
        }
    }

    private void ContinueStory()
    {
        if (CurrentStory.canContinue == false)
        {
            StartCoroutine(ExitDialogMode());
            return;
        }

        if (_displayLineCoroutine != null)
        {
            StopCoroutine(_displayLineCoroutine);
        }
        _displayLineCoroutine = StartCoroutine(_dialogeWindow.DisplayLine(CurrentStory));

       

        try
        {
            _dialogeTag.HandleTags(CurrentStory.currentTags);
        }
        catch (ArgumentException ex)
        {
            Debug.Log(ex);
        }
    }

    public void MakeChoice(int choiceIndex) 
    {
        _dialogeWindow.MakeChoice();
        CurrentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory() ;
    }
}
