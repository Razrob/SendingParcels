using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardedParcelDetector : MonoBehaviour
{
    [SerializeField] private BusinessWindowDisplay businessController;
    [SerializeField] private ParcelSendingCorrectnessIndicator lightIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.TryGetComponent(out ParcelController parcelController)) return;

        ParcelController parcel = other.transform.GetComponent<ParcelController>();

        if (!parcel.parcelData.isCorrect)
        { 
            BusinessData.AddMoney(BusinessData.payForParcel + Random.Range(-10, 4) * 100);
            lightIndicator.ActivateIndicator(Color.green);
        }
        else
        {
            lightIndicator.ActivateIndicator(Color.red);
        }  
        Destroy(other.gameObject);
    }
}
