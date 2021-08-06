using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BusinessWindowDisplay : MonoBehaviour
{

    [SerializeField] private GameObject businessWindow;

    [SerializeField] private TextMeshProUGUI moneyUI;
    [SerializeField] private TextMeshProUGUI dateUI;
    [SerializeField] private TextMeshProUGUI parcelsNumberUI; 

    private void Awake()
    { 
        CurrentDate.notifyChange += RefreshDisplays; 
    }


    private void Start()
    {
        RefreshDisplays();

        if (!Tips.tip.CallTip("Work0Tip")) Tips.tip.CallTip("Work4Tip");
    }

    private void UpdateMoneyDisplay()
    {
        moneyUI.text = BusinessData.money + "ð.";
    }

    private void UpdateDateDisplay()
    {
        dateUI.text = CurrentDate.GetDate();
    }

    private void UpdateParcelsNumberDisplay()
    {
        parcelsNumberUI.text = BusinessData.parcelsTodayNumber.ToString();
    }

    public void RefreshDisplays()
    {
        UpdateParcelsNumberDisplay();
        UpdateDateDisplay();
        UpdateMoneyDisplay();
    }

    public void ChangeDisplayBusinessWindow(bool isActive)
    {
        RefreshDisplays();

        PlayerController.controlIsActive = !isActive;

        if (isActive) Cursor.lockState = CursorLockMode.None;
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            Tips.tip.CallTip("Work1Tip");
        }

        businessWindow.SetActive(isActive);
    }
}
