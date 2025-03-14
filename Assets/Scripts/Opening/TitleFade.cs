using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TitleFade : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float stayTime = 1f;
    private Graphic graphic; 
    private Color baseColor;
    private float currentTime = 0f;
    public float delay = 1f;
    public bool canFadeOut=true;

    void Start()
    {
        graphic = GetComponent<Graphic>();
        baseColor = graphic.color;
        baseColor.a = 0f;  
        graphic.color = baseColor;

    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= delay)
        {
            float fadeStart = currentTime - delay;

            if (fadeStart < fadeDuration)
            {
                float alpha = Mathf.Lerp(0f, 1f, fadeStart / fadeDuration);
                baseColor.a = alpha;
                graphic.color = baseColor;
            }
            else if (fadeStart < fadeDuration + stayTime)
            {
                baseColor.a = 1f;
                graphic.color = baseColor;
            }
            else if (fadeStart < 2 * fadeDuration + stayTime&& canFadeOut)
            {
                float alpha = Mathf.Lerp(1f, 0f, (fadeStart - (fadeDuration + stayTime)) / fadeDuration);
                baseColor.a = alpha;
                graphic.color = baseColor;
            }
        }
    }
}


