using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        var dialogWindow = GetComponent<DialogeWindow>();

        dialogWindow.SetPortraits(value);
    }
}
