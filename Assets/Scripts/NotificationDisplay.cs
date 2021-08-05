using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationDisplay : MonoBehaviour
{
    [SerializeField] private GameObject notificationPanel;

    private Image notificationImage;
    private TextMeshProUGUI notificationText;
    private bool notIsActive;
    private Queue<string> notQueue = new Queue<string>();

    void Awake()
    { 
        notificationImage = notificationPanel.GetComponent<Image>();
        notificationText = notificationPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    } 

    public void DisplayNotification(string text)
    {
        notQueue.Enqueue(text);
        TryDisplayNot();

    }

    private void TryDisplayNot()
    {
        if (!notIsActive && notQueue.Count > 0) StartCoroutine(DisplayNotificationCorutine(notQueue.Dequeue()));
    }

    IEnumerator DisplayNotificationCorutine(string text)
    {
        notIsActive = true;
        notificationPanel.SetActive(true);
        notificationText.text = "";

        CorutineProgressChecker checker = new CorutineProgressChecker();
        StartCoroutine(SmoothAlfaChange(notificationImage, 0.9f, checker));
        while (!checker.isFinish) yield return new WaitForEndOfFrame();


        for (int i = 0; i < text.Length; i++)
        {
            notificationText.text += text[i].ToString();
            if (notificationText.text.Length > 45) notificationText.text = notificationText.text.Remove(0, 1);
            yield return new WaitForSeconds(0.075f);
        }

        yield return new WaitForSeconds(2f);

        int length = notificationText.text.Length;
        for (int i = 0; i < length; i++)
        {
            notificationText.text = notificationText.text.Remove(notificationText.text.Length - 1, 1);
            yield return new WaitForSeconds(0.02f);
        }

        checker.isFinish = false;
        StartCoroutine(SmoothAlfaChange(notificationImage, 0, checker));
        while (!checker.isFinish) yield return new WaitForEndOfFrame();
        notificationText.text = "";
        notificationPanel.SetActive(true);
        notIsActive = false;
        TryDisplayNot();
    }


    IEnumerator SmoothAlfaChange(Image image, float finalAlfa, CorutineProgressChecker checker)
    {

        float startAlfa = image.color.a;

        for (int i = 0; i <= 15; i++)
        {
            Color color = image.color;

            color.a += (finalAlfa - startAlfa) / 16;
            image.color = color;
            yield return new WaitForSeconds(0.02f);
        }

        Color finalColor = image.color;
        finalColor.a = finalAlfa;

        image.color = finalColor;

        checker.isFinish = true;

    }
}
