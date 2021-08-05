using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFridge : Interaction
{

    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private Vector3 startRotation;

    private bool isOpen;
    private bool isAnim;

    public override void Interact()
    {
        if (isAnim) return;
        isAnim = true;
        StartCoroutine(RotateAnimation()); 
    }

    IEnumerator RotateAnimation()
    {


        for(int i = 1; i <= 50; i++)
        {
            if(!isOpen) transform.localRotation = Quaternion.Euler(transform.localEulerAngles + (targetRotation - startRotation) / 50);
            else transform.localRotation = Quaternion.Euler(transform.localEulerAngles - (targetRotation - startRotation) / 50);

            yield return new WaitForSeconds(0.01f);
        }

        isOpen = !isOpen;
        isAnim = false;

    }
}
