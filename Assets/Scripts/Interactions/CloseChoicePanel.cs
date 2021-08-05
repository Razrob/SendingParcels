using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChoicePanel : MonoBehaviour
{
    [SerializeField] private GameObject choicePanel;

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        choicePanel.SetActive(false);
        PlayerController.controlIsActive = true;
    }
}
