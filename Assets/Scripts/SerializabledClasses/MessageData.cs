using UnityEngine;
using System;
[Serializable]
public struct MessageData
{
    public string senderName;
    [TextArea()]
    public string content;
    [HideInInspector] public string date;

    public MessageData(string _senderName, string _content, string _date)
    {
        senderName = _senderName;
        content = _content;
        date = _date;
    }
}