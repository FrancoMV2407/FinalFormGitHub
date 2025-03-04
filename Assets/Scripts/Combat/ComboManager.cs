using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ComboManager : MonoBehaviour
{
    public enum Element { Physic, Ignis, Sui, Glacia, Trono, Zashio, Terra, Phoro }
    public Sprite fireSprite, waterSprite, windSprite, iceSprite, electricitySprite, physicalSprite, earthSprite, metalSprite;
    public Transform[] slots; //Slots positions in screen
    public GameObject elementPrefab; // Prefab of Image wth each element
    private List<Element> elements = new List<Element>();
    private Dictionary<Element, KeyCode> keyBindings = new Dictionary<Element, KeyCode>(); //Asociate elements to keys, it's for the Start method
    private List<GameObject> elementObjects = new List<GameObject>();
    private int comboCounter = 0;
    public bool inCombo = false;

    void Start()
    {
        keyBindings[Element.Ignis] = KeyCode.I;
        keyBindings[Element.Sui] = KeyCode.U;
        keyBindings[Element.Glacia] = KeyCode.L;
        keyBindings[Element.Trono] = KeyCode.O;
        keyBindings[Element.Zashio] = KeyCode.J;
        keyBindings[Element.Physic] = KeyCode.P;
        keyBindings[Element.Terra] = KeyCode.H;
        keyBindings[Element.Phoro] = KeyCode.K;
        GenerateInitialElements();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            KeyCode keyPressed = GetPressedKey();

            if (keyPressed == KeyCode.Q || keyPressed == KeyCode.W || keyPressed == KeyCode.E ||
                keyPressed == KeyCode.A || keyPressed == KeyCode.S || keyPressed == KeyCode.D)
            {
                return;
            }

            if (keyBindings.ContainsValue(keyPressed))
            {
                if (elements[0] == keyBindings.FirstOrDefault(x => x.Value == keyPressed).Key)
                {
                    RemoveElement();
                }
                else
                {
                    ResetCombo();
                }
            }
        }
    }

    KeyCode GetPressedKey()
    {
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

    void GenerateInitialElements()
    {
        for (int i = 0; i < 5; i++)
        {
            AddNewElement();
        }
    }

    void AddNewElement()
    {
        Element newElement = (Element)Random.Range(0, 8);
        elements.Add(newElement);
        GameObject obj = Instantiate(elementPrefab, slots[elements.Count - 1].transform);
        RectTransform rt = obj.GetComponent<RectTransform>();
        rt.localPosition = Vector3.zero; 
        obj.GetComponent<Image>().sprite = GetElementSprite(newElement);
        elementObjects.Add(obj);
    }

    void RemoveElement()
    {
        StartCoroutine(FadeAndMove());
        comboCounter++;
        inCombo = comboCounter >= 5;
    }

    System.Collections.IEnumerator FadeAndMove()
    {
        GameObject obj = elementObjects[0];
        elements.RemoveAt(0);
        elementObjects.RemoveAt(0);

        Image img = obj.GetComponent<Image>();
        RectTransform rt = obj.GetComponent<RectTransform>();
        float alpha = 1;
        Vector3 startPos = rt.position;
        Vector3 endPos = startPos + Vector3.down * 50;
        float duration = 0.5f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            alpha = Mathf.Lerp(1, 0, elapsed / duration);
            rt.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
            img.color = new Color(1, 1, 1, alpha);
            yield return null;
        }

        Destroy(obj);
        ShiftElements();
        AddNewElement();
    }

    void ShiftElements()
    {
        for (int i = 0; i < elementObjects.Count; i++)
        {
            StartCoroutine(MoveToPosition(elementObjects[i].GetComponent<RectTransform>(), slots[i].position));
        }
    }

    System.Collections.IEnumerator MoveToPosition(RectTransform obj, Vector3 targetPos)
    {
        Vector3 startPos = obj.position;
        float elapsed = 0;
        float duration = 0.1f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            obj.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            yield return null;
        }
        obj.position = targetPos;
    }

    void ResetCombo()
    {
        comboCounter = 0;
        inCombo = false;
    }

    Sprite GetElementSprite(Element element)
    {
        return element switch
        {
            Element.Ignis => fireSprite,
            Element.Sui => waterSprite,
            Element.Glacia => iceSprite,
            Element.Trono => electricitySprite,
            Element.Zashio => windSprite,
            Element.Physic => physicalSprite,
            Element.Terra => earthSprite,
            Element.Phoro => metalSprite,
            _ => null,
        };
    }
}
