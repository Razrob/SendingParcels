using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public static class CurrentDate
{
    public static int dayNumber { get; private set; } = 1;

    private static int day = 1;
    private static int month = 1;
    private static int year = 2021;


    public static int hour = 8;
    public static int minute = 0;
    public static int seconds = 0;

    public static List<IParamsChange> onParamsChange = new List<IParamsChange>();


    public static void SetDate(int _day, int _month, int _year)
    {
        day = _day;
        month = _month;
        year = _year;
    }

    public static int ChangeTimeFromSleep()
    {
        int sleepHoursNumber;

        if (hour >= 8)
        {
            sleepHoursNumber = 24 - hour + 8;
            SkipDay();
        }
        else sleepHoursNumber = 8 - hour; 

        hour = 8;
        minute = 0;
        seconds = 0;

        return sleepHoursNumber;
    }

    public static void SkipDay()
    {
        dayNumber++;
         

        if (day >= DateTime.DaysInMonth(year, month))
        {
            day = 1;
            if (month >= 12)
            {
                month = 1;
                year++;
            }
            else month++;
        }
        else
        {
            day++;
        }

        BusinessData.parcelsTodayNumber += Random.Range(BusinessData.maxParcelsInDayNumber / 3, BusinessData.maxParcelsInDayNumber);
         
        foreach (IParamsChange obj in onParamsChange) obj.Refresh(); 

    }
    public static string GetDate()
    {
        string date;

        date = day.ToString().Length == 1 ? "0" + day : day.ToString();
        date += ".";
        date += month.ToString().Length == 1 ? "0" + month : month.ToString();
        date += ".";
        date += year;

        return date;
    }

    public static void SetTime(int _hour, int _minute)
    {
        hour = _hour;
        minute = _minute;
    }

    public static void SkipSecond()
    {
        if (seconds >= 59)
        {
            SkipMinute();
            seconds = 0;
        }
        else seconds++;

    }
    public static void SkipMinute()
    {
        if (minute >= 59)
        {
            minute = 0;
            if (hour >= 23)
            {
                SkipDay();
                hour = 0;
            }
            else hour++;
        }
        else minute++;
        PlayerStats.SkipMinute(); 

    }


}
