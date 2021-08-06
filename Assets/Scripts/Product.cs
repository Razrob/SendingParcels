using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour, IInteraction
{
    [SerializeField] private string productName;
    public string ProductName { get { return productName; } }

    [SerializeField] private int satietyIncrease;
    [SerializeField] private int waterSatietyIncrease;
    [SerializeField] private int cheerfulnessIncrease;

    private Fridge fridgeController;
    public int indexInFridge { get; private set; } = -1;


    public void Interact()
    {
        PlayerStats.ChangeStats(satietyIncrease, waterSatietyIncrease, cheerfulnessIncrease); 

        fridgeController.RemoveProduct(this);
    }

    public void SetParams(int index, Fridge fridge)
    {
        indexInFridge = index;
        fridgeController = fridge; 
    }

}
