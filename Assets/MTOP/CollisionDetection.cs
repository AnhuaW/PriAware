using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public bool audioOn = false;
    public bool boundingBoxOn = false;
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
                audioSource.enabled = true;
            }

            if (boundingBoxOn)
            {
                targetObject.GetComponent<LineRenderer>().enabled = true;
            }

            if (textLabelOn)
            {
                TextMeshPro textMesh = targetObject.GetComponentInChildren<TextMeshPro>();
                if (textMesh != null)
                {
                    textMesh.enabled = true;
                }
            }
            
            if (ttsOn)
            {
                TextToSpeechController ttsController = targetObject.GetComponentInChildren<TextToSpeechController>();
                if (ttsController != null && !ttsController.descriptionPlayed)
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
            Debug.Log("Object exited FOV: " + other.gameObject.name);
            if (audioOn)
            {
                AudioSource audioSource = other.gameObject.GetComponentInChildren<AudioSource>();
                audioSource.enabled = false;
            }

            if (boundingBoxOn)
            {
                targetObject.GetComponent<LineRenderer>().enabled = false;
            }

            if (textLabelOn)
            {
                TextMeshPro textMesh = targetObject.GetComponentInChildren<TextMeshPro>();
                if (textMesh != null)
                {
                    textMesh.enabled = false;
                }
            }
        }
    }
}
