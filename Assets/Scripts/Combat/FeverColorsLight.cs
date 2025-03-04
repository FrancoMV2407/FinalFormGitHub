using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverColorsLight : MonoBehaviour
{
    public Light directionalLight;
    public ComboManager comboManager;

    private Color originalColor = Color.white; 
    public float colorSpeed = 1.5f;
    private float hue = 0f; 

    void Start()
    {
        if (directionalLight == null)
        {
            directionalLight = GetComponent<Light>();
        }

        originalColor = directionalLight.color;
    }

    void Update()
    {
        if (comboManager.inCombo)
        {
            hue += Time.deltaTime * colorSpeed;

            if (hue > 1f)
            {
                hue -= 1f;
            }

            directionalLight.color = Color.HSVToRGB(hue, 1f, 1f);
        }
        else
        {
            directionalLight.color = originalColor;
        }
    }
}
