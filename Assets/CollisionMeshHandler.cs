using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollisionHandler : MonoBehaviour
{
    public GameObject highlightPrefab;
    [SerializeField] private float radius = 0.1f; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PrivacyRisk")
        {
            Debug.Log(other.gameObject.name + " detected");
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            HighlightCollisionArea(other, collisionPoint);
        }
    }

    private void HighlightCollisionArea(Collider collidedObject, Vector3 collisionPoint)
    {
        // Spawn a highlight effect at the collision point
        if (highlightPrefab != null)
        {
            GameObject highlight = Instantiate(highlightPrefab, collisionPoint, Quaternion.identity);
            // Optionally, parent the highlight to the collided object to keep it aligned
            highlight.transform.SetParent(collidedObject.transform);
            //Destroy(highlight, 2f);
        }
        else
        {
            Debug.LogWarning("Highlight Prefab is not assigned.");
        }
    }
}

