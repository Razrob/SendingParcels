using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static float satiety { get; private set; } = 50;
    public static float waterSatiety { get; private set; } = 50;
    public static float cheerfulness { get; private set; } = 50;

    public static float decreaseSatietySpeedInHour { get; } = 8;
    public static float decreaseWaterSatietySpeedInHour { get; } = 8;
    public static float decreaseCheerfulnessSpeedInHour { get; } = 6;

    public static IParamsChange onPlayerStatsChange;

    private static int minuteCounter;

    public static void SkipMinute()
    {
        minuteCounter++;
        if(minuteCounter >= 5)
        {
            minuteCounter = 0;
            ChangeStats(-decreaseSatietySpeedInHour / 12, -decreaseWaterSatietySpeedInHour / 12, -decreaseCheerfulnessSpeedInHour / 12);
        }
    }

    public static void StatsDisplay()
    {
        onPlayerStatsChange.Refresh(0);
        onPlayerStatsChange.Refresh(1);
        onPlayerStatsChange.Refresh(2);
    }

    public static void ChangeStats(float _satiety, float _waterSatiety, float _cheerfulness)
    {
        satiety += _satiety;
        waterSatiety += _waterSatiety;
        cheerfulness += _cheerfulness;

        if (satiety < 0) satiety = 0;
        if (waterSatiety < 0) waterSatiety = 0;
        if (cheerfulness < 0) cheerfulness = 0;

        if (satiety > 100) satiety = 100;
        if (waterSatiety > 100) waterSatiety = 100;
        if (cheerfulness > 100) cheerfulness = 100;

        if (satiety % 20 <= decreaseSatietySpeedInHour / 12 || _satiety > 0) onPlayerStatsChange.Refresh(0);
        if (waterSatiety % 20 <= decreaseWaterSatietySpeedInHour / 12 || _waterSatiety > 0) onPlayerStatsChange.Refresh(1);
        if (cheerfulness % 20 <= decreaseCheerfulnessSpeedInHour / 12 || _cheerfulness > 0) onPlayerStatsChange.Refresh(2); 
    }

}
