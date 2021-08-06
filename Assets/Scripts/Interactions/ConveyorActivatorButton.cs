using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorActivatorButton : MonoBehaviour, IInteraction
{
    [SerializeField] private float pressOffcet;

    private ParcelGenerator parcelGenerator;
    private ConveyorMovement[] conveyorController;


    private void Start()
    {
        parcelGenerator = FindObjectOfType<ParcelGenerator>();
        conveyorController = FindObjectsOfType<ConveyorMovement>(); 
    }

    public void Interact()
    {
        StartCoroutine(Press());
        Tips.tip.CallTip("Work2Tip");
    }

    private IEnumerator Press()
    {
        parcelGenerator.spawning = !parcelGenerator.spawning;

        for (int i = 0; i < conveyorController.Length; i++) conveyorController[i].active = !conveyorController[i].active;

        transform.localPosition = transform.localPosition - Vector3.up * pressOffcet;
        yield return new WaitForSeconds(.75f); 
        transform.localPosition = transform.localPosition + Vector3.up * pressOffcet;
    } 
}
