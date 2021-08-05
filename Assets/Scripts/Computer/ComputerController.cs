using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerController : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;

    [SerializeField] private GameObject computerWindow;
    [SerializeField] private TextMeshProUGUI dateUI;
    [SerializeField] private TextMeshProUGUI moneyUI;

    void Start()
    {
        if (!TipsManager.Tips.CallTip("StartTip")) TipsManager.Tips.CallTip("SkipDayTip");
        //BusinessData.AddMoney(10000); 
    }


    public void UpdateDateDisplay()
    {
        dateUI.text = CurrentDate.GetDate();
    }

    public void UpdateMoneyDisplay()
    {
        moneyUI.text = BusinessData.money.ToString();
    }



    public void SetComputerWindowActive(bool active)
    {
        PlayerController.controlIsActive = !active;


        if (active) Cursor.lockState = CursorLockMode.None;
        else Cursor.lockState = CursorLockMode.Locked;

        if (active) ChangeActiveWindow(0);

        computerWindow.SetActive(active);
        UpdateDateDisplay();
        UpdateMoneyDisplay(); 
    }


    public void ChangeActiveWindow(int index)
    {
        foreach (GameObject window in windows) window.SetActive(false);
        windows[index].SetActive(true);
    }
}
