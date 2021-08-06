using System;
using UnityEngine;

[Serializable]
public class Tip
{
    public string tipName;
    public string tipContent;
    [HideInInspector] public bool tipWasShowned;
}