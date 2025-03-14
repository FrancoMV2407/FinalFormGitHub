using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
    public float rotationSpeed;

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.Rotate(0, -rotationSpeed, 0 * Time.deltaTime);
    }
}
