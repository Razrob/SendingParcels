using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct ProductData
{
    public string productName;
    public int positionIndex;

    public ProductData(string _productName, int _positionIndex)
    {
        productName = _productName;
        positionIndex = _positionIndex;
    }
}
