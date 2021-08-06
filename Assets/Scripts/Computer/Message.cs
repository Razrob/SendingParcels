using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Message : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI senderNameText;  
    [SerializeField] public TextMeshProUGUI contentText;  
    [SerializeField] public TextMeshProUGUI dateText; 

    [HideInInspector] public EmailHandler emailController;

    [HideInInspector] public MessageData messageData;


    public void UpdateUI(bool fullMessage)
    {
        senderNameText.text = $"Отправитель: {messageData.senderName}";
        dateText.text = messageData.date;

        if(fullMessage) contentText.text = messageData.content;
        else
        {
            if (messageData.content.Length > 30) contentText.text = messageData.content.Substring(0, 30).Replace("\n", string.Empty) + "...";  
            else contentText.text = messageData.content;
        }
    }

    public void OnMessageClick()
    {
        if (emailController != null) emailController.OpenFullMessage(new MessageData(messageData.senderName, messageData.content, messageData.date));
    }

}
