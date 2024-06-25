using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpeakerTag), typeof(MethodTag), typeof(PortraitTag))]
public class Tags : MonoBehaviour
{
    private readonly Dictionary<string, ITag> _map = new ();

    private void Start()
    {
        _map.Add("speaker", GetComponent<SpeakerTag>());
        _map.Add("method", GetComponent<MethodTag>());
        _map.Add("portrait", GetComponent<PortraitTag>());
    }

    public ITag GetValue(string key)
    {
        return _map.GetValueOrDefault(key);
    }
}
