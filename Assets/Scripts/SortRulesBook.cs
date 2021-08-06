using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SortRulesBook : MonoBehaviour
{
    [SerializeField] private GameObject rulesWindow;

    [SerializeField] private TwoPages[] twoPages;


    private int activeTwoPagesIndex = 0; 

    public void ChangeActiveTwoPages(int offcet) // -1 or 1
    {
        int maxTwoPagesIndex = twoPages.Length - 1;
        if (HardLevelChanger.hardLevel == 0) return;
        if (maxTwoPagesIndex > (HardLevelChanger.hardLevel - 1) / 2) maxTwoPagesIndex = (HardLevelChanger.hardLevel - 1) / 2;

        if (activeTwoPagesIndex + offcet < 0 || activeTwoPagesIndex + offcet > maxTwoPagesIndex) return;
        activeTwoPagesIndex += offcet;

        foreach (var twoPage in twoPages)
        {
            twoPage.pages[0].pageGameObject.SetActive(false);
            twoPage.pages[1].pageGameObject.SetActive(false);
            twoPage.pages[0].pageGameObject.transform.parent.gameObject.SetActive(false);
        }

        twoPages[activeTwoPagesIndex].pages[0].pageGameObject.transform.parent.gameObject.SetActive(true);
        if (twoPages[activeTwoPagesIndex].pages[0].pageCount <= HardLevelChanger.hardLevel) twoPages[activeTwoPagesIndex].pages[0].pageGameObject.SetActive(true);
        if (twoPages[activeTwoPagesIndex].pages[1].pageCount <= HardLevelChanger.hardLevel) twoPages[activeTwoPagesIndex].pages[1].pageGameObject.SetActive(true);

    }

    public void ChangeDisplayRulesWindow(bool active)
    {
        activeTwoPagesIndex = 0;
        if (active) ChangeActiveTwoPages(0);

        PlayerController.controlIsActive = !active;
        Cursor.lockState = (CursorLockMode)Enum.GetValues(typeof(CursorLockMode)).GetValue(Convert.ToInt32(!active));

        rulesWindow.SetActive(active);


    }

}
