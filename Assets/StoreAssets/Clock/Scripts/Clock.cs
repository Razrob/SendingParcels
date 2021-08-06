using UnityEngine;
using System.Collections;

public class Clock : MonoBehaviour
{ 
    private TextMesh text;  

    void Start()
    {
        text = GetComponent<TextMesh>();  
    }

    void Update()
    { 
        text.text = "";
        text.text += (CurrentDate.hour.ToString().Length == 1 ? "0" + CurrentDate.hour.ToString() : CurrentDate.hour.ToString()) + ":" + 
            (CurrentDate.minute.ToString().Length == 1 ? "0" + CurrentDate.minute.ToString() : CurrentDate.minute.ToString()); 

    } 
    
}

