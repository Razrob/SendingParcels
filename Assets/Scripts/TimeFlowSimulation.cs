using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFlowSimulation : MonoBehaviour
{
    [SerializeField] private float timeSpeed = 1;
    [SerializeField] private AutoEarnings autoWorkManager;

    private float min; 

    private void Update()
    {
        min += Time.deltaTime * timeSpeed / 60;

        if (min >= 1f / 60)
        {
            int secsNumber = System.Convert.ToInt32(min * 60);
            for (int i = 0; i < secsNumber; i++) CurrentDate.SkipSecond(); 
            min = 0;
            autoWorkManager.SortCentersWork(secsNumber);
        }

    }
}
