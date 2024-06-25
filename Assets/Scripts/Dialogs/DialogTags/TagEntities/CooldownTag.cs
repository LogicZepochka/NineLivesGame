using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        float number = (float)Convert.ToDouble(value.Replace(".", ","));

        var dialogWindow = GetComponent<DialogeWindow>();
        try
        {
            dialogWindow.SetCooldown(number);
        }
        catch(ArgumentException ex)
        {
            Debug.LogError(ex.Message);
        }
    }
}
