using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameStoryNarrator : MonoBehaviour
{
    [SerializeField] private StoryMessage[] emailsSendedInSomeDay;


    private void Awake()
    {
        CurrentDate.notifyChange += SendDayEmail;
        TipsSender.Tip.CallTip("Start");
        SendDayEmail();
    }

    private void SendDayEmail()
    {
        foreach(StoryMessage message in emailsSendedInSomeDay)
        {
            if (message.sendDay > CurrentDate.dayNumber) break;
            if (message.sendDay == CurrentDate.dayNumber) EmailHandler.Email.SendMailMessage(message.messageData.senderName, message.messageData.content);
        }
    } 

}
