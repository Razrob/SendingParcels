using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailHandler : MonoBehaviour
{
    [SerializeField] private Message fullMessage;

    [SerializeField] private GameObject messagePrefab;
    [SerializeField] private Transform messagesTransformParent;
     
    private List<MessageData> messages = new List<MessageData>();

    public static EmailHandler Email { get; private set; }

    private void Awake()
    {
        if (Email == null) Email = this;
    }

    private void Start()
    {
        //SendMailMessage("Неизвестный", "Сообщение");
        //SendMailMessage("Работодатель", "Ты уволен");
        //SendMailMessage("Работодатель", "Ты принят в компанию по разработке комплексов");
    } 

    public void SendMailMessage(string senderName, string content)
    {
        Message message = Instantiate(messagePrefab, messagesTransformParent).GetComponent<Message>();
        message.emailController = this;

        message.messageData = new MessageData(senderName, content, CurrentDate.GetDate().Substring(0, 5));
        message.UpdateUI(false);

        messages.Add(message.messageData);

    } 

    public void OpenFullMessage(MessageData messageData)
    {
        fullMessage.messageData = messageData;
        fullMessage.UpdateUI(true);

        fullMessage.gameObject.SetActive(true);
    }

    public void CloseFullMessage()
    {
        fullMessage.gameObject.SetActive(false);
    }

}


