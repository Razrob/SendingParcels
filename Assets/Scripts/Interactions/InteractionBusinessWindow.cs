using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBusinessWindow : Interaction
{
    [SerializeField] private BusinessController businessController;
    [SerializeField] private bool activity = true; 

    public override void Interact()
    {
        if (isInteractable) businessController.ChangeDisplayBusinessWindow(activity);
    }

}
