using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBackground : MonoBehaviour
{
    public float movement = 5f;
    public GameObject background1;
    public GameObject background2;

    private float backgroundWidth;
    private float time=0f;  
    public float pause = 3f;
    public float stopDelay;
    public bool isPausable =false;

    void Start()
    {
        backgroundWidth = background1.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        time += Time.deltaTime;  

        if (time >= pause && isPausable)
        {
             movement = Mathf.Lerp(movement, 0f, (time - pause) / stopDelay);
        }

        background1.transform.Translate(Vector3.left * movement * Time.deltaTime);
        background2.transform.Translate(Vector3.left * movement * Time.deltaTime);

        if (background1.transform.position.x <= -backgroundWidth)
        {
            background1.transform.position = new Vector3(background2.transform.position.x + backgroundWidth, background1.transform.position.y, background1.transform.position.z);
        }

        if (background2.transform.position.x <= -backgroundWidth)
        {
            background2.transform.position = new Vector3(background1.transform.position.x + backgroundWidth - 0.2f, background2.transform.position.y, background2.transform.position.z);
        }
    }
}



