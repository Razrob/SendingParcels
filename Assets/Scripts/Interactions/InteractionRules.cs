using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionRules : Interaction
{
    [SerializeField] RulesDisplayController rulesDisplayController;
    public override void Interact()
    {
        if (isInteractable) rulesDisplayController.ChangeDisplayRulesWindow(true);
    }
}
