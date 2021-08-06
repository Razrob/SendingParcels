using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessWindowOpener : MonoBehaviour, IInteraction
{
    [SerializeField] private BusinessWindowDisplay businessController;
    [SerializeField] private bool activity = true; 

    public void Interact()
    {
        businessController.ChangeDisplayBusinessWindow(activity);
    }

}
