using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParcelSendingCorrectnessIndicator : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxIntencity;

    private Light light;
     

    private void Start()
    {
        light = GetComponent<Light>();
    } 

    public void ActivateIndicator(Color color)
    {
        light.color = color; 
        StartCoroutine(SmoothLight());
    }
     

    private IEnumerator SmoothLight()
    {
        light.enabled = true;
        float startIntencity = light.intensity;

        for (int i = 1; i <= 10; i++)
        {
            light.intensity += (maxIntencity - startIntencity) / 10;
            yield return new WaitForSeconds(0.1f / speed);
        }

        for (int i = 1; i <= 10; i++)
        {
            light.intensity -= (maxIntencity - startIntencity) / 10;
            yield return new WaitForSeconds(0.1f / speed);
        }
        light.enabled = false;
    }

}
