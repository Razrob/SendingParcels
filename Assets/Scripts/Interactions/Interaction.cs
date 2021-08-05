using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Interaction : MonoBehaviour
{
    [HideInInspector] public bool isInteractable = true;

    public virtual void Interact() { }

    protected void ChangeOnClickedButton(Button button, Action action)
    { 
        Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
        buttonClickedEvent.AddListener(new UnityEngine.Events.UnityAction(action));
        button.onClick = buttonClickedEvent;
    }

    [Serializable]
    protected class ChoicePanel
    {
        public GameObject choicePanel;
        public Button acceptButton;
        public TextMeshProUGUI choiceText;
    }

    [Serializable]
    protected class WarningPanel
    {
        public GameObject warningPanel; 
        public TextMeshProUGUI warningText;
    }

}


