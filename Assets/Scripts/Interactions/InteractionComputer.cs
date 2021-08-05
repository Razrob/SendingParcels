using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComputer : Interaction
{
    [SerializeField] private ComputerController computerController;


    void Start()
    {
        
    }

    public override void Interact()
    {
        computerController.SetComputerWindowActive(true);
    }
}
