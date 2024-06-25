using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTrigger : MonoBehaviour
{
    [SerializeField] public TextAsset _inkJSON;

    private bool _isPlayerEnter;

    private DialogeController _dialogController;
    private DialogeWindow _dialogWindow;

    AudioSource _audioSource;

    private void Start()
    {
        _isPlayerEnter = false;

        _dialogController = FindObjectOfType<DialogeController>();
        _dialogWindow = FindObjectOfType<DialogeWindow>();
        _audioSource = GetComponent<AudioSource>(); 
    }

    public void ChangeDialog(TextAsset newDialog)
    {
        _inkJSON = newDialog;
    }

    private void Update()
    {
        if(_dialogWindow.IsPlaying == true || _isPlayerEnter == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _dialogController.EnterDialogMode(_inkJSON, _audioSource);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<Player>() != null)
        {
            _isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Player>() != null)
        {
            _isPlayerEnter = false;
        }
    }

}
