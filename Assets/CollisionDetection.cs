using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject targetObject = other.gameObject;
        Debug.Log(targetObject.name + " entered");
        if (targetObject.CompareTag("PrivacyRisk"))
        {
            Debug.Log("Object entered FOV: " + targetObject.name);

            // Optional: Play spatial audio
            AudioSource audioSource = targetObject.GetComponentInChildren<AudioSource>();
            audioSource.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject targetObject = other.gameObject;
        Debug.Log(targetObject.name + " exited");
        if (other.gameObject.CompareTag("PrivacyRisk"))
        {
            Debug.Log("Object exited FOV: " + other.gameObject.name);
            AudioSource audioSource = other.gameObject.GetComponentInChildren<AudioSource>();
            audioSource.enabled = false;
        }
    }
}
