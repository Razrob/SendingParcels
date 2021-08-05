using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    [SerializeField] private Tip[] tips;
    [SerializeField] private NotificationDisplay notificationDisplay;

    public static TipsManager Tips { get; private set; }

    void Awake()
    {
        if(Tips == null) Tips = this;
    } 

    public bool CallTip(int tipIndex)
    {
        if(tips[tipIndex].tipWasShowned) return false;

        notificationDisplay.DisplayNotification(tips[tipIndex].tipContent);
        tips[tipIndex].tipWasShowned = true;
        return true;

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
[System.Serializable]
public class Tip
{
    public string tipName;
    public string tipContent;
    [HideInInspector] public bool tipWasShowned;
}

