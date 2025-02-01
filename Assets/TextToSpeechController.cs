using System;
using UnityEngine;
using Meta.WitAi.TTS;
using Meta.WitAi.TTS.Integrations;
using Meta.WitAi.TTS.Utilities;
using TMPro;

public class TextToSpeechController : MonoBehaviour
{
    public TTSSpeaker ttsSpeaker;
    public TextMeshPro textMeshPro; // For UI Text components
    public bool descriptionPlayed = false;
    public void Start()
    {
        //textMeshPro = GetComponent<TextMeshPro>();
    }

    public void PlayAudioDescription()
    {
        if (ttsSpeaker != null && textMeshPro != null)
        {
            string textToSpeak = textMeshPro.text;
            ttsSpeaker.Speak(textToSpeak);
            //descriptionPlayed = true;
        }
    }

    public void ShowText()
    {
        textMeshPro.enabled = true;
    }

    public void HideText()
    {
        textMeshPro.enabled = false;
    }
}