using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BoundingBox : MonoBehaviour
{
    public Color startColor = Color.grey;
    public Color endColor = Color.grey;
    public LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.widthMultiplier = 0.02f; // Thickness of the lines
        lineRenderer.loop = true; // Connect the last vertex to the first
        lineRenderer.useWorldSpace = true;

        // Set material and color
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.material.renderQueue = 4000; // Overlay render queue
    }

    void Start()
    {
        // Initialize the LineRenderer
        lineRenderer.widthMultiplier = 0.02f; // Thickness of the lines
        lineRenderer.loop = true; // Connect the last vertex to the first
        lineRenderer.useWorldSpace = true;

        // Set material and color
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;

        DrawBoxCollider();
        lineRenderer.enabled = false;
    }

    void Update()
    {
        // Continuously update the bounding box to follow the GameObject
        DrawBoxCollider();
    }

    void DrawBoxCollider()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null) return;

        // Calculate the 8 corners of the box in world space
        Vector3 center = transform.TransformPoint(boxCollider.center);
        Vector3 size = boxCollider.size * 0.5f;
        Vector3[] corners = new Vector3[8];

        corners[0] = center + transform.TransformVector(new Vector3(-size.x, -size.y, -size.z));
        corners[1] = center + transform.TransformVector(new Vector3(size.x, -size.y, -size.z));
        corners[2] = center + transform.TransformVector(new Vector3(size.x, size.y, -size.z));
        corners[3] = center + transform.TransformVector(new Vector3(-size.x, size.y, -size.z));
        corners[4] = center + transform.TransformVector(new Vector3(-size.x, -size.y, size.z));
        corners[5] = center + transform.TransformVector(new Vector3(size.x, -size.y, size.z));
        corners[6] = center + transform.TransformVector(new Vector3(size.x, size.y, size.z));
        corners[7] = center + transform.TransformVector(new Vector3(-size.x, size.y, size.z));

        // Define the edges to connect the corners
        int[] edges =
        {
            0, 1, 2, 3, 0, 4, 5, 1, 5, 6, 2, 6, 7, 3, 7, 4
        };

        Vector3[] edgePositions = new Vector3[edges.Length];
        for (int i = 0; i < edges.Length; i++)
        {
            edgePositions[i] = corners[edges[i]];
        }

        // Assign positions to the LineRenderer
        lineRenderer.positionCount = edgePositions.Length;
        lineRenderer.SetPositions(edgePositions);
    }

    public void UpdateColor()
    {
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;
    }
}
