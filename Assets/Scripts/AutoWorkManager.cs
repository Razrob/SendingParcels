using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWorkManager : MonoBehaviour
{
    private BusinessController businessController;

    private int seconds; 


    public void SortCentersWork(int passedSeconds)
    {
        if (BusinessData.parcelsTodayNumber <= 0 || BusinessData.generalProductivity <= 0) return;
        seconds += passedSeconds;

        int secondsForParcel = 3600 / BusinessData.generalProductivity; 
        if (seconds < secondsForParcel) return;

        int parcelCount = seconds / secondsForParcel;
        seconds -= secondsForParcel * parcelCount;

        for (int i = 0; i < parcelCount; i++)
        {
            BusinessData.parcelsTodayNumber--;
            BusinessData.AddMoney(BusinessData.payForParcel + Random.Range(-7, 7) * 100);
        }

        if (businessController == null) businessController = FindObjectOfType<BusinessController>();
        if (businessController != null)
        {
            businessController.UpdateParcelsNumberDisplay();
            businessController.UpdateMoneyDisplay();
        }

    }

}
