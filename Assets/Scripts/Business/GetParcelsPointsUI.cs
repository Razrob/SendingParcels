using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GetParcelsPointsUI : MonoBehaviour
{
    [SerializeField] private GetParcelsPointUI[] getParcelsPointUI;

    [SerializeField] private BusinessWindowDisplay businessController;

    private void Start()
    {

        for (int i = 0; i < BusinessData.getParcelsPointsNumber; i++) RefreshGetParcelsPoints(i);
    }

    public void BuyParcelsPoint()
    {
        int activeGetParcelsPointIndex = BusinessData.getParcelsPointsNumber;
        if (activeGetParcelsPointIndex >= getParcelsPointUI.Length) return;
         
        string price = getParcelsPointUI[activeGetParcelsPointIndex].price.text;
        price = price.Substring(price.IndexOf("(") + 1, price.IndexOf("р") - price.IndexOf("(") - 1);

        if (!BusinessData.MakePurchase(Convert.ToInt32(price))) return;

        BusinessData.getParcelsPointsNumber++;
        BusinessData.maxParcelsInDayNumber += BusinessData.maxParcelsInDaysForGetParcelsPoints[activeGetParcelsPointIndex];
         

        RefreshGetParcelsPoints(activeGetParcelsPointIndex); 
        businessController.RefreshDisplays();

    }
     
    private void RefreshGetParcelsPoints(int activeGetParcelsPointIndex)
    {
        getParcelsPointUI[activeGetParcelsPointIndex].blockPanel.SetActive(false);
        getParcelsPointUI[activeGetParcelsPointIndex].price.text = "(куплено)";
    }

}

[Serializable]
public class GetParcelsPointUI
{ 
    public GameObject blockPanel; 
    public TextMeshProUGUI price; 
}