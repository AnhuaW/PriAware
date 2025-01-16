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
    public bool showMesh = false;
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
                LineRenderer lineRenderer = targetObject.GetComponent<LineRenderer>();
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
                if (ttsController != null && !ttsController.ttsSpeaker.IsSpeaking)
                {
                    ttsController.PlayAudioDescription();
                }
            }
        }

        if (showMesh)
        {
            ShowCollisionMesh(other, other.ClosestPoint(transform.position));
            Debug.Log((other.gameObject.name + "mesh showing"));
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

    private void ShowCollisionMesh(Collider collidedObject, Vector3 collisionPoint)
    {
        //Get the MeshFilter and MeshRenderer
        MeshFilter meshFilter = collidedObject.GetComponent<MeshFilter>();
        MeshRenderer meshRenderer = collidedObject.GetComponent<MeshRenderer>();

        if (meshFilter != null && meshRenderer != null)
        {
            // Get the mesh and highlight the collision area
            Mesh originalMesh = meshFilter.mesh;
            Vector3[] vertices = originalMesh.vertices;
            int[] triangles = originalMesh.triangles;

            // Find the vertices near the collision point
            Vector3 localCollisionPoint = collidedObject.transform.InverseTransformPoint(collisionPoint);
            for (int i = 0; i < vertices.Length; i++)
            {
                float distance = Vector3.Distance(vertices[i], localCollisionPoint);
                if (distance < 0.1f) // Threshold for "collision area"
                {
                    // Optionally: Modify vertex colors to highlight this area
                    Debug.Log($"Collision at vertex: {vertices[i]}");
                }
            }

            // Optional: Create a new material or shader effect to show the collision area
            Material highlightMaterial = new Material(Shader.Find("Standard"));
            highlightMaterial.color = Color.cyan;
            meshRenderer.material = highlightMaterial;
        }
    }
}
