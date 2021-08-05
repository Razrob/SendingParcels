using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTeleportDoor : Interaction
{
    [SerializeField] private ChoicePanel choicePanel;
    [SerializeField] private WarningPanel warningPanel;
    [SerializeField] private bool ifCheck = true;

    [SerializeField] private string choiceText;

    [SerializeField] private string loadingSceneName;
    [SerializeField] private string unloadingSceneName;

    public override void Interact()
    { 
        if (isInteractable)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerController.controlIsActive = false;
            /// 
            if (!ifCheck || ((PlayerStats.cheerfulness > 20 && PlayerStats.satiety > 20 && PlayerStats.waterSatiety > 20)))
            {
                choicePanel.choicePanel.SetActive(true);
                choicePanel.choiceText.text = choiceText;
                ChangeOnClickedButton(choicePanel.acceptButton, new System.Action(Teleport));
            }
            else
            {
                PlayerStats.StatsDisplay();
                warningPanel.warningPanel.SetActive(true);
                warningPanel.warningText.text = "Ваши показатели слишком низкие"; 
            }
        }
    }   
    public void Teleport()
    {
        Cursor.lockState = CursorLockMode.Locked;
        SceneLoadController sceneLoadController = FindObjectOfType<SceneLoadController>();
        if(sceneLoadController != null) sceneLoadController.LoadScene(loadingSceneName, SceneManager.GetActiveScene().name);
        choicePanel.choicePanel.SetActive(false);
        PlayerController.controlIsActive = true;
        choicePanel.acceptButton.onClick.RemoveAllListeners();
    }
}
