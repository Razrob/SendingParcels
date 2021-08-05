using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class BusinessController : MonoBehaviour, IParamsChange
{

    [SerializeField] private GameObject businessWindow;

    [SerializeField] private TextMeshProUGUI moneyUI;
    [SerializeField] private TextMeshProUGUI dateUI;
    [SerializeField] private TextMeshProUGUI parcelsNumberUI;

    private GameManager gameManager;

    private void Awake()
    {
        CurrentDate.onParamsChange.Add(this); 
    } 
    

    void Start()
    {
        UpdateMoneyDisplay();
        if (!TipsManager.Tips.CallTip("Work0Tip")) TipsManager.Tips.CallTip("Work4Tip");
    }

    public void UpdateMoneyDisplay()
    {
        moneyUI.text = BusinessData.money + "ð.";
    }

    public void UpdateDateDisplay()
    {
        dateUI.text = CurrentDate.GetDate();
    }

    public void UpdateParcelsNumberDisplay()
    {
        parcelsNumberUI.text = BusinessData.parcelsTodayNumber.ToString();
    }

    public void Refresh(int index = 0)
    {

        UpdateParcelsNumberDisplay();
        UpdateDateDisplay();
        UpdateMoneyDisplay();
    }

    public void ChangeDisplayBusinessWindow(bool isActive)
    {
        Refresh();

        PlayerController.controlIsActive = !isActive;

        if (isActive) Cursor.lockState = CursorLockMode.None;
        else
        {
            Cursor.lockState = CursorLockMode.Locked; 
            TipsManager.Tips.CallTip("Work1Tip");
        }

        businessWindow.SetActive(isActive);
    }
}
