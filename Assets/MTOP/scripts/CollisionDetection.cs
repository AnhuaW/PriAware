using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetection : MonoBehaviour
{
    public bool audioOn = false;
    public bool boundingBoxOn = false;
    public bool iconOn = false;
    public bool textLabelOn = false;
    public bool ttsOn = false;
    private void OnTriggerEnter(Collider other)
    {
        GameObject targetObject = other.gameObject;
        //Debug.Log(targetObject.name + " entered");
        if (targetObject.CompareTag("PrivacyRisk"))
        {
            Debug.Log("Object entered FOV: " + targetObject.name);

            // Optional: Play spatial audio
            if (audioOn)
            {
                AudioSource audioSource = targetObject.GetComponentInChildren<AudioSource>();
                if (audioSource != null && audioSource.CompareTag("earcons"))
                {
                    audioSource.enabled = true;
                }
            }

            if (boundingBoxOn)
            {
                LineRenderer lineRenderer = targetObject.GetComponent<LineRenderer>();
                if (lineRenderer != null)
                {
                    targetObject.GetComponent<LineRenderer>().enabled = true;
                }
            }

            if (textLabelOn)
            {
                TextMeshPro textMesh = targetObject.GetComponentInChildren<TextMeshPro>();
                if (textMesh != null)
                {
                    textMesh.enabled = true;
                }
            }

            if (iconOn)
            {
                ToggleIconImages(targetObject, true);
            }
            
            if (ttsOn)
            {
                TextToSpeechController ttsController = targetObject.GetComponentInChildren<TextToSpeechController>();
                if (ttsController != null && !ttsController.ttsSpeaker.IsSpeaking)
                {
                    ttsController.PlayAudioDescription();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject targetObject = other.gameObject;
        //Debug.Log(targetObject.name + " exited");
        if (other.gameObject.CompareTag("PrivacyRisk"))
        {
            Debug.Log("Object exited FOV: " + targetObject.name);
            if (audioOn)
            {
                AudioSource audioSource = targetObject.GetComponentInChildren<AudioSource>();
                if (audioSource != null && audioSource.CompareTag("earcons"))
                {
                    audioSource.enabled = false;
                }
            }

            if (boundingBoxOn)
            {
                LineRenderer lineRenderer = targetObject.GetComponent<LineRenderer>();
                if (lineRenderer != null)
                {
                    targetObject.GetComponent<LineRenderer>().enabled = false;
                }
            }

            if (textLabelOn)
            {
                TextMeshPro textMesh = targetObject.GetComponentInChildren<TextMeshPro>();
                if (textMesh != null)
                {
                    textMesh.enabled = false;
                }
            }

            if (iconOn)
            {
                ToggleIconImages(targetObject, false);
            }
        }
    }
    
    /// <summary>
    /// Toggles the visibility of Image components inside icon child objects.
    /// </summary>
    private void ToggleIconImages(GameObject targetObject, bool enable)
    {
        
        // Find all icon GameObjects that are children of targetObject
        Transform[] iconChildren = targetObject.GetComponentsInChildren<Transform>();

        foreach (Transform iconChild in iconChildren)
        {
            if (iconChild.CompareTag("Icon")) // Only process objects tagged "Icon"
            {
                // Find Image components in all children of this icon child
                Image[] images = iconChild.GetComponentsInChildren<Image>();

                foreach (Image img in images)
                {
                    img.enabled = enable; // Enable or disable each Image
                }
            }
        }
    }
}
