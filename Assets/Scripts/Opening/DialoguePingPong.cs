using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialoguePingPong : MonoBehaviour
{
    public TextMeshProUGUI firstSpeaker;
    public TextMeshProUGUI secondSpeaker;

    public Persona5Effect firstSpeakerEffect;
    public Persona5Effect secondSpeakerEffect;

    public List<string> sender = new List<string>();
    public List<string> response = new List<string>();

    private int textIndex = 0;
    private bool ongoingSpeech = false;

    public bool sequenceHasBegun = false;
    public int limit = 0;
    public bool IsFirstSpeakerTalking => textIndex % 2 == 0;
    public bool IsSecondSpeakerTalking => textIndex % 2 != 0;

    public float startConversation;
    private float currentTime = 0f;

    public float textSpeed = 0.05f;

    void Start()
    {
        firstSpeaker.text = string.Empty;
        secondSpeaker.text = string.Empty;
        limit = sender.Count + response.Count;
    }

    void Update()
    {
        if (!sequenceHasBegun && currentTime >= startConversation)
        {
            sequenceHasBegun = true;
            textIndex = 0;  
            StartCoroutine(TypeFirstLine());
        }
        else
        {
            currentTime += Time.deltaTime;
        }
    }

    IEnumerator TypeFirstLine()
    {
        if (sender.Count > 0 && response.Count > 0)
        {
            firstSpeaker.text = string.Empty;
            secondSpeaker.text = string.Empty;

            yield return StartCoroutine(TypeText(sender[0], firstSpeaker, true));
            firstSpeakerEffect.StartEffect();
            textIndex++;  
        }
    }

    public void NextLine()
    {
        if (sequenceHasBegun && !ongoingSpeech)
        {
            if (textIndex >= limit)
            {
                firstSpeaker.text = string.Empty;
                secondSpeaker.text = string.Empty;
                sequenceHasBegun = false;
                SceneManager.LoadScene("LoadingScreen");
            }
            else
            {
                if (NextLineTick())
                {
                    if (IsFirstSpeakerTalking)
                    {
                        StartCoroutine(TypeText(sender[textIndex / 2], firstSpeaker, true));
                        secondSpeaker.text = string.Empty;
                        firstSpeakerEffect.StartEffect();
                        secondSpeakerEffect.StopEffect();
                    }
                    else
                    {
                        StartCoroutine(TypeText(response[(textIndex - 1) / 2], secondSpeaker, false));
                        firstSpeaker.text = string.Empty;
                        secondSpeakerEffect.StartEffect();
                        firstSpeakerEffect.StopEffect();
                    }
                    textIndex++;  
                }
            }
        }
    }

    public bool NextLineTick()
    {
        return textIndex < sender.Count + response.Count;
    }

    private IEnumerator TypeText(string textToType, TextMeshProUGUI speakerText, bool isFirstSpeaker)
    {
        ongoingSpeech = true;
        speakerText.text = string.Empty;

        foreach (char letter in textToType)
        {
            speakerText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        ongoingSpeech = false;
    }
}










