using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tags))]
public class DialogeTag : MonoBehaviour
{
    private Tags _tags;
    private DialogeWindow _dialogeWindow;

    public void Init()
    {
        _tags = GetComponent<Tags>();
    }

    public void HandleTags(List<string> tags)
    {        
        if (tags.Count == 0) return;
        foreach (var tagValue in tags)
        {
            string[] keyTag = tagValue.Split(":");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправильное оформление тега, просьба исправить!");
            }

            string key = keyTag[0].Trim();
            string value = keyTag[1].Trim();
            

            if (key == "portrait")
            {
                _tags.GetValue(key).Calling(value);
                continue;
            }
            if (key == "speaker")
            {
                _tags.GetValue(key).Calling(value);
                
                continue;
            }
            if (key == "method")
            {
                _tags.GetValue(key).Calling(value);
                continue;
            }

        }
    }
}
