using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendParcelDetect : MonoBehaviour
{
    [SerializeField] private BusinessController businessController; 
    [SerializeField] private LightIndicator lightIndicator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Parcel") return;

        ParcelController parcel = other.transform.GetComponent<ParcelController>();

        if (parcel.parcelData.isCorrect)
        {
            BusinessData.AddMoney(BusinessData.payForParcel + Random.Range(-7, 7) * 100);
            lightIndicator.ActivateIndicator(Color.green);
        }
        else
        {
            lightIndicator.ActivateIndicator(Color.red);
        } 
        Destroy(other.gameObject); 
    }
}
