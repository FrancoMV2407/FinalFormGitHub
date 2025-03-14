using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class TextRandomizer : MonoBehaviour
{
    [SerializeField] private List<string> flavorText = new List<string>();
    [SerializeField] private GameObject contents;
    void Start()
    {
        TextGenerator(); 
    }
    public void TextGenerator()
    {
        TextMeshProUGUI textMeshPro = contents.GetComponent<TextMeshProUGUI>();
        int randomIndex = Random.Range(0, flavorText.Count);
        textMeshPro.text = flavorText[randomIndex];
    }
}



