using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
 
[Serializable]
public class ProductUI
{
    public TextMeshProUGUI priceWithName;
    public TextMeshProUGUI productsNumber;
    [HideInInspector] public int productsInBasketNumber;

    public int price
    {
        get
        {
            string price = priceWithName.text;
            price = price.Substring(price.IndexOf("(") + 1, price.IndexOf("ð.)") - price.IndexOf("(") - 1);
            return System.Convert.ToInt32(price);
        }
    }


}