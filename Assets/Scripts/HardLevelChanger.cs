using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardLevelChanger : MonoBehaviour
{

    [SerializeField] private NotificationDisplay notificationDisplay;

    private string hardLevelChangeNot = "¬ правилах сортировки по€вились новые пункты";

    public static int hardLevel = 0;
    public static int[] dayForChangeHardLevel = new int[] { 1, 2, 3, 5, 6, 7, 8, 9, 11 };


    void Awake()
    {
        //CurrentDate.onParamsChange.Add(this);
        CurrentDate.notifyChange += ChangeHardLevel;
    }

    private void ChangeHardLevel() 
    {
        int oldValue = hardLevel;
        for (int i = 0; i < dayForChangeHardLevel.Length; i++)
        {
            if (dayForChangeHardLevel[i] > CurrentDate.dayNumber) break;
            hardLevel = i;
        }
        if (oldValue == hardLevel) return;

        notificationDisplay.DisplayNotification(hardLevelChangeNot);
    }
     
}
