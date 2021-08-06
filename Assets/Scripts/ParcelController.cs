using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelController : MonoBehaviour
{
    [SerializeField] private ParcelSize parcelSize;
    [SerializeField] public Vector3 positionOnPlayer;

    [SerializeField] private TextMesh senderNameText;
    [SerializeField] private TextMesh senderAddressText;
    [SerializeField] private TextMesh senderPostcodeText;

    [SerializeField] private TextMesh recipientNameText;
    [SerializeField] private TextMesh recipientAddressText;
    [SerializeField] private TextMesh recipientPostcodeText;

    [SerializeField] private MeshRenderer mark;
    [SerializeField] private MeshRenderer stump;
    [SerializeField] private TextMesh massText;
    [SerializeField] private TextMesh scaleText;
    [SerializeField] private TextMesh valueText;
    [SerializeField] private TextMesh dateText;
    [SerializeField] private TextMesh parcelCodeText;

    [SerializeField] private Material[] marks;
    [SerializeField] private Material[] incorrectMarks;
    [SerializeField] private Material stumpRus;
    [SerializeField] private Material[] incorrectStumps;
    [SerializeField] private Vector3[] stumpPosition;



    public ParcelData parcelData { get; private set; } = new ParcelData();



    private void Start()
    {
        parcelData.GenerateData(parcelSize, HardLevelChanger.hardLevel);
        UIUpdate();
    }

    private void UIUpdate()
    {
        senderNameText.text = parcelData.senderName;
        senderAddressText.text = parcelData.senderAddress;
        senderPostcodeText.text = parcelData.senderPostcode;

        recipientNameText.text = parcelData.recipientName;
        recipientAddressText.text = parcelData.recipientAddress;
        recipientPostcodeText.text = parcelData.recipientPostcode;

        scaleText.text = parcelData.scale;
        valueText.text = parcelData.value + "0";
        dateText.text = parcelData.date;
        parcelCodeText.text = parcelData.code;
        massText.text = parcelData.mass;

        if (parcelData.mark) mark.material = marks[Random.Range(0, marks.Length)];
        else
        {
            if (Random.Range(0,3) >= 0) mark.material = incorrectMarks[Random.Range(0, incorrectMarks.Length)];
        }

        if (parcelData.stump)
        {
            stump.material = stumpRus;
            stump.transform.localPosition = stumpPosition[Random.Range(0, stumpPosition.Length)];
        }
        else
        {
            int index = Random.Range(0, incorrectStumps.Length + 1);
            if (index != incorrectStumps.Length) stump.material = incorrectStumps[index];
        }
    } 
}
