using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BusinessData
{
    public static int money { get; private set; } = 1500;
    
    public static bool sortCentersIsLaunched { get; set; }

    public static List<SortCenter> sortCenters { get; set; } = new List<SortCenter>();
    public static int generalProductivity { get; set; } = 0;

    public static int maxParcelsInDayNumber { get; set; }

    public static int getParcelsPointsNumber { get; set; }
    public static int promotionsNumber { get; set; }

    public static int[] maxParcelsInDaysForGetParcelsPoints { get; } = new int[] { 10, 15, 30, 45, 70, 100, 200 };
    public static int[] maxParcelsInDaysForPromotions { get; } = new int[] { 10, 15, 30, 45, 70, 100, 200 };

    public static int payForParcel { get; private set; } = 1500;

    public static int parcelsTodayNumber { get; set; } = 4;

    public static bool MakePurchase(int price)
    {
        if(price <= money)
        {
            money -= price;
            return true;
        }
        return false;
    }

    public static void AddMoney(int value)
    {
        money += value;
    }
}

public class SortCenter
{
    public int productivity { get; set; }

    public int conveyorNumber { get; set; }
    public int sorterNumber { get; set; }

    public int conveyorPrice { get; set; } = 20000;
    public int sorterPrice { get; set; } = 20000;
} 