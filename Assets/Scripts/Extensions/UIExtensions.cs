using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class UIExtensions
{

    public static void SetActionOnClickedButton(this Button button, Action action)
    {
        Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
        buttonClickedEvent.AddListener(new UnityAction(action));
        button.onClick = buttonClickedEvent;
    }
}
