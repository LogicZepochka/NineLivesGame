using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogMethods))]
public class MethodTag : MonoBehaviour, ITag
{
    public void Calling(string value)
    {
        var dialogMethods = GetComponent<DialogMethods>();

        var method = dialogMethods.GetType().GetMethod(value);

        method.Invoke(dialogMethods, null);
    }
}
