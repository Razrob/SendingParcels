using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{

    private TextMesh text;
     
    GameObject pointerSeconds;
    GameObject pointerMinutes;
    GameObject pointerHours;


    void Start()
    {
        text = GetComponent<TextMesh>();
        //pointerSeconds = transform.Find("rotation_axis_pointer_seconds").gameObject;
        //pointerMinutes = transform.Find("rotation_axis_pointer_minutes").gameObject;
        //pointerHours = transform.Find("rotation_axis_pointer_hour").gameObject;
         
    }

    void Update()
    { 
        text.text = "";
        text.text += (CurrentDate.hour.ToString().Length == 1 ? "0" + CurrentDate.hour.ToString() : CurrentDate.hour.ToString()) + ":" + 
            (CurrentDate.minute.ToString().Length == 1 ? "0" + CurrentDate.minute.ToString() : CurrentDate.minute.ToString());


        //float rotationSeconds = (360.0f / 60.0f) * CurrentDate.seconds;
        //float rotationMinutes = (360.0f / 60.0f) * CurrentDate.minute;
        //float rotationHours = ((360.0f / 12.0f) * CurrentDate.hour) + ((360.0f / (60.0f * 12.0f)) * CurrentDate.minute);

        //pointerSeconds.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationSeconds);
        //pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
        //pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

    }
}

