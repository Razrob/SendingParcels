using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Bed : MonoBehaviour, IInteraction
{  
    [SerializeField] private string choiceText = "�� ������������� ������ ���� �����?";
    [SerializeField] private ChoicePanel choicePanel;
    [SerializeField] private Image sleepPanel;

    [SerializeField] private Vector3 sleepPosition;
    [SerializeField] private Vector3 sleepRotation;


    public void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        PlayerController.controlIsActive = false;
        choicePanel.choiceText.text = choiceText; 
        choicePanel.acceptButton.SetActionOnClickedButton(new Action(ToSleep));
        choicePanel.choicePanel.SetActive(true);

    }

    public void ToSleep()
    { 
        StartCoroutine(SleepAnimation()); 
    } 

    private IEnumerator SleepAnimation()
    {
        choicePanel.choicePanel.SetActive(false);
        choicePanel.acceptButton.onClick.RemoveAllListeners();
        Cursor.lockState = CursorLockMode.Locked;

        Transform player = FindObjectOfType<PlayerController>().transform.GetChild(0);
        Vector3 startPos = player.position;
        Vector3 startRot = player.eulerAngles;
          
        for(int i = 1; i <= 50; i++)
        {
            player.position += (sleepPosition - startPos) / 50; 
            player.rotation = Quaternion.Euler(player.eulerAngles + (sleepRotation - startRot) / 50); 
            yield return new WaitForSeconds(0.01f);
        }

        Color32 color = sleepPanel.color;
        sleepPanel.gameObject.SetActive(true);
        for (int i = 0; i <= 255; i++)
        {
            color.a = (byte)i;
            sleepPanel.color = color;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        int sleepHours = CurrentDate.ChangeTimeFromSleep();

        for (int i = 255; i >= 0; i--)
        {
            color.a = (byte)i;
            sleepPanel.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        sleepPanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);

        for (int i = 1; i <= 50; i++)
        {
            player.position -= (sleepPosition - startPos) / 50;
            player.rotation = Quaternion.Euler(player.eulerAngles - (sleepRotation - startRot) / 50);
            yield return new WaitForSeconds(0.01f);
        }
        //TipsSender.Tip.CallTip("FoodTip");

        PlayerStats.ChangeStats(sleepHours * -PlayerStats.decreaseSatietySpeedInHour, sleepHours * -PlayerStats.decreaseWaterSatietySpeedInHour, sleepHours * PlayerStats.decreaseCheerfulnessSpeedInHour * 2); 
         
        PlayerController.controlIsActive = true;
    }

}