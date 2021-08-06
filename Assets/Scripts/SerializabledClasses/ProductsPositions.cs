using UnityEngine;
 
[System.Serializable]
public struct ProductPosition
{
    public Vector3 productPosition;
    [HideInInspector] public bool isBusy;
}