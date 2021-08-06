using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TeleportDoor : MonoBehaviour, IInteraction
{
    [SerializeField] private ChoicePanel choicePanel;
    [SerializeField] private WarningPanel warningPanel;
    [SerializeField] private bool ifCheck = true;

    [SerializeField] private string choiceText;

    [SerializeField] private string loadingSceneName;
    [SerializeField] private string unloadingSceneName;

    public void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        PlayerController.controlIsActive = false;

        if (!ifCheck || ((PlayerStats.cheerfulness > 20 && PlayerStats.satiety > 20 && PlayerStats.waterSatiety > 20)))
        {
            choicePanel.choicePanel.SetActive(true);
            choicePanel.choiceText.text = choiceText;
            choicePanel.acceptButton.SetActionOnClickedButton(new Action(Teleport));
        }
        else
        {
            PlayerStats.StatsDisplay();
            warningPanel.warningPanel.SetActive(true);
            warningPanel.warningText.text = "Ваши показатели слишком низкие";
        }

    }
    public void Teleport()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneLoader sceneLoadController = FindObjectOfType<SceneLoader>();
        if(sceneLoadController != null) sceneLoadController.LoadScene(loadingSceneName, SceneManager.GetActiveScene().name);
        choicePanel.choicePanel.SetActive(false);
        PlayerController.controlIsActive = true;
        choicePanel.acceptButton.onClick.RemoveAllListeners();
    }
}
