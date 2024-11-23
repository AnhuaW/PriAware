using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ConeGenerator : MonoBehaviour
{
  public float viewDistance = 10f;    // Length of the cone
    public float fovAngle = 45f;       // Field of view angle (degrees)
    public int resolution = 30;       // Number of segments for the circular base
    public Material coneMaterial;     // Material for visualization

    private Mesh coneMesh;

    void Start()
    {
        // Generate and assign the cone mesh
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        coneMesh = CreateConeMesh();
        meshFilter.mesh = coneMesh;

        // Assign material for visualization
        if (coneMaterial != null)
        {
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.material = coneMaterial;
        }
    }

    Mesh CreateConeMesh()
    {
        Mesh mesh = new Mesh();

        // Vertices
        int numVertices = resolution + 2; // Tip + circular base vertices
        Vector3[] vertices = new Vector3[numVertices];
        vertices[0] = Vector3.zero; // Tip of the cone

        float angleStep = 360f / resolution;
        for (int i = 0; i < resolution; i++)
        {
            float angle = Mathf.Deg2Rad * (i * angleStep);
            float x = Mathf.Sin(angle) * viewDistance * Mathf.Tan(Mathf.Deg2Rad * fovAngle / 2);
            float z = Mathf.Cos(angle) * viewDistance * Mathf.Tan(Mathf.Deg2Rad * fovAngle / 2);
            vertices[i + 1] = new Vector3(x, -viewDistance, z); // Base vertex
        }
        vertices[vertices.Length - 1] = Vector3.down * viewDistance; // Center of the base

        // Triangles
        int[] triangles = new int[resolution * 3 + resolution * 3];
        int triIndex = 0;

        // Side triangles
        for (int i = 0; i < resolution; i++)
        {
            triangles[triIndex++] = 0; // Tip
            triangles[triIndex++] = i + 1;
            triangles[triIndex++] = (i + 1) % resolution + 1;
        }

        // Base triangles
        int baseCenterIndex = vertices.Length - 1;
        for (int i = 0; i < resolution; i++)
        {
            triangles[triIndex++] = baseCenterIndex;
            triangles[triIndex++] = (i + 1) % resolution + 1;
            triangles[triIndex++] = i + 1;
        }

        // Assign vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }
}