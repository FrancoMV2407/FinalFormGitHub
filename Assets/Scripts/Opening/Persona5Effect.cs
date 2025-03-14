using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persona5Effect : MonoBehaviour
{
    public float ping = 0.95f;
    public float pong = 1.05f;
    public float pulsePower = 2f;
    public float startBouncing = 2f;
    private Vector3 size;
    private bool characterTalking = false;
    private float currentTime = 0f;

    void Start()
    {
        size = transform.localScale;
    }
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= startBouncing)
        {
            if (characterTalking)
            {
                float scale = Mathf.Lerp(ping, pong, Mathf.PingPong(Time.time * pulsePower, 1));
                transform.localScale = size * scale;
            }
            else
            {
                transform.localScale = size;
            }
        }
    }
    public void StartEffect()
    {
        characterTalking = true;
    }

    public void StopEffect()
    {
        characterTalking = false;
    }
}






