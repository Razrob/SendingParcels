using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IndicatorChange : MonoBehaviour
{
    [SerializeField] private Image indicator;

    private bool isLaunched;

     
    public void ChangeColor(Color finalColor)
    {
        if (isLaunched) StopAllCoroutines();
         
        StartCoroutine(SmoothChangeColor(finalColor));

        isLaunched = true;

    }

    private IEnumerator SmoothChangeColor(Color finalColor)
    { 
        if (indicator.color.a < 0.02f) indicator.color = finalColor; 
        StartCoroutine(SmoothAlfaChange(indicator, 1)); 
         
        for (int i = 0; i <= 63; i++)
        {
            Color startColor = indicator.color;
            Color color = indicator.color;
            color += (finalColor - startColor) / 64;
            color.a = indicator.color.a;

            indicator.color = color;

            yield return new WaitForSeconds(0.01f);
        } 


        yield return new WaitForSeconds(1f);

        CorutineProgressChecker checker = new CorutineProgressChecker();
        StartCoroutine(SmoothAlfaChange(indicator, 0, checker));
        while (!checker.isFinish) yield return new WaitForEndOfFrame(); 

    }

    private IEnumerator SmoothAlfaChange(Image indicator, float finalAlfa, CorutineProgressChecker checker = null)
    {
        float startAlfa = indicator.color.a;

        int iterationNumber = System.Convert.ToInt32(Mathf.Abs(finalAlfa - startAlfa) / 0.0625f);

        for (int i = 0; i < iterationNumber; i++)
        {
            Color color = indicator.color;

            color.a += (finalAlfa - startAlfa) / 16;
            indicator.color = color;
            yield return new WaitForSeconds(0.02f);
        }

        Color finalColor = indicator.color;
        finalColor.a = finalAlfa;

        indicator.color = finalColor;

        if(checker != null) checker.isFinish = true;

    }

}