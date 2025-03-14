using UnityEngine;
using UnityEngine.UI;

public class HoverEffect : MonoBehaviour
{
    public Button button;
    private RectTransform rectTransform;
    public float enlarge;
    private Vector3 originalSize;

    void Start()
    {
        rectTransform = button.GetComponent<RectTransform>();
        originalSize = rectTransform.localScale;
    }

    public void OnPointerEnter()
    {
        rectTransform.localScale = originalSize * enlarge;
    }

    public void OnPointerExit()
    {
        rectTransform.localScale = originalSize;
    }
}

