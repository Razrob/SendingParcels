using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Interaction
{
    [SerializeField] private int satietyIncrease;
    [SerializeField] private int waterSatietyIncrease;
    [SerializeField] private int cheerfulnessIncrease;

    private FridgeController fridgeController;
    public int indexInFridge { get; private set; } = -1;


    public override void Interact()
    {
        PlayerStats.ChangeStats(satietyIncrease, waterSatietyIncrease, cheerfulnessIncrease); 

        fridgeController.RemoveProduct(indexInFridge, gameObject);
    }

    public void SetParams(int index, FridgeController fridge)
    {
        indexInFridge = index;
        fridgeController = fridge; 
    }

}
