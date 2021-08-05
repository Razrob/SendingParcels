using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTurnConveyorButton : Interaction
{
    [SerializeField] private float pressOffcet;

    private ParcelGenerator parcelGenerator;
    private ConveyorController[] conveyorController;


    void Start()
    {
        parcelGenerator = FindObjectOfType<ParcelGenerator>();
        conveyorController = FindObjectsOfType<ConveyorController>(); 
    }

    public override void Interact()
    {
        if(isInteractable) StartCoroutine(Press());
        TipsManager.Tips.CallTip("Work2Tip");
    }

    IEnumerator Press()
    {
        parcelGenerator.spawning = !parcelGenerator.spawning;

        for (int i = 0; i < conveyorController.Length; i++) conveyorController[i].active = !conveyorController[i].active;

        transform.localPosition = transform.localPosition - Vector3.up * pressOffcet;
        yield return new WaitForSeconds(.75f); 
        transform.localPosition = transform.localPosition + Vector3.up * pressOffcet;
    } 
}
