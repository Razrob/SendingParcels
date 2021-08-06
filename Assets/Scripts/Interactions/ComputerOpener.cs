using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerOpener : MonoBehaviour, IInteraction
{
    [SerializeField] private ComputerWindowDisplay computerController;
     
    public void Interact()
    {
        computerController.SetComputerWindowActive(true);
    }
}
