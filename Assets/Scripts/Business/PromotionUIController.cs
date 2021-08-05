using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class PromotionUIController : MonoBehaviour
{

    [SerializeField] private PromotionsUI[] promotionsUI;

    [SerializeField] private BusinessController businessController;

    private void Start()
    {

        for (int i = 0; i < BusinessData.promotionsNumber; i++) RefreshPromoutions(i);
    }

    public void BuyPromotion()
    {
        int activePromotionIndex = BusinessData.promotionsNumber;
        if (activePromotionIndex >= promotionsUI.Length) return;

        string price = promotionsUI[activePromotionIndex].price.text;
        price = price.Substring(price.IndexOf("(") + 1, price.IndexOf("р") - price.IndexOf("(") - 1);

        if (!BusinessData.MakePurchase(Convert.ToInt32(price))) return;

        BusinessData.promotionsNumber++;
        BusinessData.maxParcelsInDayNumber += BusinessData.maxParcelsInDaysForPromotions[activePromotionIndex];
         

        RefreshPromoutions(activePromotionIndex);

        businessController.UpdateMoneyDisplay();
    }

    private void RefreshPromoutions(int activePromotionIndex)
    {
        promotionsUI[activePromotionIndex].blockPanel.SetActive(false);
        promotionsUI[activePromotionIndex].price.text = "(куплено)";
    }




}

[Serializable]
public class PromotionsUI
{
    public GameObject blockPanel;
    public TextMeshProUGUI price;
}