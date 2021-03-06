using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsSender : MonoBehaviour
{
    [SerializeField] private Tip[] tips;
    [SerializeField] private NotificationDisplay notificationDisplay;

    public static TipsSender Tip { get; private set; }

    private void Awake()
    {
        if(Tip == null) Tip = this;
    }  

    public bool CallTip(string tipName)
    {
        Tip tip = null;
        foreach (Tip t in tips)
        { 
            if (t.tipName == tipName)
            {
                tip = t;
                break;
            }
        } 
        if (tip.tipWasShowned) return false; 
        notificationDisplay.DisplayNotification(tip.tipContent);
        tip.tipWasShowned = true;
        return true;
    }

}

