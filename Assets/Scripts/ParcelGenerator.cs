using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelGenerator : MonoBehaviour
{

    public bool spawning = true;
    [SerializeField] private float spawnDelay;

    [SerializeField] private BusinessWindowDisplay businessController;

    [SerializeField] private GameObject[] parcels;
    [SerializeField] private Vector3 parcelSpawnPosition;

    

    private void Start()
    { 
        StartCoroutine(RepeatParcelGen());
    }
     
    private IEnumerator RepeatParcelGen()
    {
        if(spawning) GenerateParcel();
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(RepeatParcelGen());
    }

    private void GenerateParcel()
    {
        if (BusinessData.parcelsTodayNumber <= 0)
        { 
            Tips.tip.CallTip("Work3Tip");
            return;
        }

        Instantiate(parcels[Random.Range(0, parcels.Length)], parcelSpawnPosition, Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
        BusinessData.parcelsTodayNumber--;
        businessController.RefreshDisplays();
    }

}
