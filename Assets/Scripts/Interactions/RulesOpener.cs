using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesOpener : MonoBehaviour, IInteraction
{
    [SerializeField] SortRulesBook rulesDisplayController;
    public void Interact()
    {
        rulesDisplayController.ChangeDisplayRulesWindow(true);
    }
}
