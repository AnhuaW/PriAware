using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi.TTS;
using Meta.WitAi.TTS.Integrations;
using Meta.WitAi.TTS.Utilities;
using TMPro;

public class TextToSpeechController : MonoBehaviour
{
    public TTSSpeaker ttsSpeaker;
    public TTSSpeechSplitter ttsSplitter;
    public TextMeshPro textMeshPro;
    public TextMeshPro ttsText;
    // For UI Text components
    public GazeInteractable gazeInteractable;
    public bool descriptionPlayed = false;
    
    private Queue<string> speechQueue = new Queue<string>();
    private bool isSpeaking = false; 
    public void Start()
    {
        //textMeshPro = GetComponent<TextMeshPro>();
        if (ttsSpeaker != null)
        {
            ttsSpeaker.Events.OnPlaybackQueueComplete.AddListener(PlayNextInQueue);
        }
    }

    public void PlayAudioDescription()
    {
        if (ttsSpeaker != null && textMeshPro)
        {
            string textToSpeak = ttsText.text;
            List<string> phrases = new List<string> { textToSpeak };

            // Split the text into phrases
            ttsSplitter.OnPreprocessTTS(ttsSpeaker, phrases);

            // Add phrases to queue
            speechQueue.Clear();
            foreach (string phrase in phrases)
            {
                speechQueue.Enqueue(phrase);
            }

            // Start playing if not already speaking
            if (!isSpeaking)
            {
                isSpeaking = true;
                PlayNextInQueue();
            }
        }
    }
    
    private void PlayNextInQueue()
    {
        if (speechQueue.Count > 0)
        {
            string nextPhrase = speechQueue.Dequeue();
            ttsSpeaker.Speak(nextPhrase);
        }
        else
        {
            isSpeaking = false;
            descriptionPlayed = true;
            gazeInteractable.OnAudioComplete.Invoke();
        }
    }

    private void OnDestroy()
    {
        if (ttsSpeaker != null)
        {
            ttsSpeaker.Events.OnPlaybackQueueComplete.RemoveListener(PlayNextInQueue);
        }
    }

    public void ShowText()
    {
        if (!isSpeaking)
        {
            textMeshPro.enabled = true;
        }
    }

    public void HideText()
    {
        textMeshPro.enabled = false;
    }
}