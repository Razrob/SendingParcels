using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class SortCentersUI : MonoBehaviour
{

    [SerializeField] private SortCenterUI[] sortCentersUI;

    [SerializeField] private BusinessWindowDisplay businessController;

    private void Start()
    {
        for(int i = 0; i < BusinessData.sortCenters.Count; i++) RefreshSortCenterUI(i);
    }


    public void BuySortCenter()
    {
        int activeSortCenterIndex = BusinessData.sortCenters.Count;
        if (activeSortCenterIndex >= sortCentersUI.Length) return;

        string price = sortCentersUI[activeSortCenterIndex].price.text;
        price = price.Substring(price.IndexOf("(") + 1, price.IndexOf("р") - price.IndexOf("(") - 1); 

        if (!BusinessData.MakePurchase(Convert.ToInt32(price))) return;

        BusinessData.sortCenters.Add(new SortCenter());

        sortCentersUI[activeSortCenterIndex].blockPanel.SetActive(false);
        sortCentersUI[activeSortCenterIndex].price.transform.gameObject.SetActive(false);
        sortCentersUI[activeSortCenterIndex].infoPanel.SetActive(true);

        businessController.RefreshDisplays();
    }


    public void BuyConveyor(int sortCenterIndex)
    {
        if (!BusinessData.MakePurchase(BusinessData.sortCenters[sortCenterIndex].conveyorPrice)) return;

        BusinessData.sortCenters[sortCenterIndex].conveyorNumber++;
        BusinessData.sortCenters[sortCenterIndex].conveyorPrice += 1000;

        RecalculateSortCenterData(sortCenterIndex);
    }

    public void BuySorter(int sortCenterIndex)
    { 
        if (!BusinessData.MakePurchase(BusinessData.sortCenters[sortCenterIndex].sorterPrice)) return;

        BusinessData.sortCenters[sortCenterIndex].sorterNumber++;
        BusinessData.sortCenters[sortCenterIndex].sorterPrice += 1000;

        RecalculateSortCenterData(sortCenterIndex);
    }

    private void RecalculateSortCenterData(int sortCenterIndex)
    {
        int newProductivity = Mathf.Min(BusinessData.sortCenters[sortCenterIndex].sorterNumber, BusinessData.sortCenters[sortCenterIndex].conveyorNumber);
        if (BusinessData.sortCenters[sortCenterIndex].productivity < newProductivity)
        {
            BusinessData.sortCenters[sortCenterIndex].productivity = newProductivity;
            BusinessData.generalProductivity++;
        }

        RefreshSortCenterUI(sortCenterIndex);
    }

    private void RefreshSortCenterUI(int sortCenterIndex)
    {
        sortCentersUI[sortCenterIndex].conveyorNumber.text = BusinessData.sortCenters[sortCenterIndex].conveyorNumber.ToString();
        sortCentersUI[sortCenterIndex].sortersNumber.text = BusinessData.sortCenters[sortCenterIndex].sorterNumber.ToString();
        sortCentersUI[sortCenterIndex].productivity.text = "Производительность: " + BusinessData.sortCenters[sortCenterIndex].productivity + "/час";

        sortCentersUI[sortCenterIndex].buyConveyorButtonText.text = $"Купить еще ({BusinessData.sortCenters[sortCenterIndex].conveyorPrice})";
        sortCentersUI[sortCenterIndex].buySorterButtonText.text = $"Купить еще ({BusinessData.sortCenters[sortCenterIndex].sorterPrice})";

        businessController.RefreshDisplays();
    }


}

[Serializable]
public class SortCenterUI
{
    public GameObject blockPanel;
    public GameObject infoPanel;

    public TextMeshProUGUI price;
    public TextMeshProUGUI productivity;
    public TextMeshProUGUI conveyorNumber;
    public TextMeshProUGUI sortersNumber;

    public TextMeshProUGUI buyConveyorButtonText;
    public TextMeshProUGUI buySorterButtonText;

}