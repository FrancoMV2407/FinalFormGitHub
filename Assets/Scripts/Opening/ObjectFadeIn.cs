using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectFadeIn : MonoBehaviour
{
    public float fade = 1f;     
    public float stayTime = 1f;  
    private Material material;
    private Color baseColor;
    private float currentTime = 0f;  
    public string nextSceneName;
    public bool canFadeOut=true;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        baseColor = material.color;
        baseColor.a = 0f; 
        material.color = baseColor;
    }

    void Update()
    {
        currentTime += Time.deltaTime; 

        if (currentTime < fade)
        {
            float alpha = Mathf.Lerp(0f, 1f, currentTime / fade);
            baseColor.a = alpha;
            material.color = baseColor;
        }
        else if (currentTime < fade + stayTime)
        {
            baseColor.a = 1f;
            material.color = baseColor;
        }
        else if (currentTime < fade + stayTime + fade && canFadeOut)
        {
            float alpha = Mathf.Lerp(1f, 0f, (currentTime - (fade + stayTime)) / fade);
            baseColor.a = alpha;
            material.color = baseColor;
        }
        if (currentTime >= fade + stayTime + fade || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

