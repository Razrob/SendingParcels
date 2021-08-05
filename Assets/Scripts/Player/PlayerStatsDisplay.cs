using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour, IParamsChange
{
    [SerializeField] private Image satietyIndicator;
    [SerializeField] private Image waterSatietyIndicator;
    [SerializeField] private Image cheerfulnessIndicator;

    [SerializeField] private IndicatorChange satietyIndicatorChange;
    [SerializeField] private IndicatorChange waterSatietyIndicatorChange;
    [SerializeField] private IndicatorChange cheerfulnessIndicatorChange;


    private void Awake()
    {
        PlayerStats.onPlayerStatsChange = this; 
    }
     
    public void Refresh(int statIndex)
    {
        DisplayIndicators(statIndex);
    }

    public void DisplayIndicators(int statIndex)
    { 
        if (statIndex == 0)
        {
            satietyIndicatorChange.ChangeColor(GetColorFromStat(PlayerStats.satiety)); 
        }
        if (statIndex == 1)
        {
            waterSatietyIndicatorChange.ChangeColor(GetColorFromStat(PlayerStats.waterSatiety));
        }
        if (statIndex == 2)
        { 
            cheerfulnessIndicatorChange.ChangeColor(GetColorFromStat(PlayerStats.cheerfulness));
        }
    }



    private Color GetColorFromStat(float stat) // stat from 0 to 100 // 0 - red, 100 - green
    {
        Color finalColor;

        if (stat <= 50)
        {
            finalColor = Color.red;
            finalColor += (Color.yellow - Color.red) / 50f * stat; 
        }
        else
        {
            finalColor = Color.yellow;
            finalColor += (Color.green - Color.yellow) / 50f * (stat - 50); 
        }

        finalColor -= new Color(0.25f, 0.25f, 0); 
        return finalColor;
    }  
}

public class CorutineProgressChecker
{
    public bool isFinish;
}

public interface IParamsChange
{
    public void Refresh(int statIndex = 0); 
}
