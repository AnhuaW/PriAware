using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollisionHandler : MonoBehaviour
{
    public GameObject spherePrefab;
    public float radius = 3f;
    public float spawnDelay = 0.2f;
    public float gridDensity = 0.25f; // Spacing of points for low-vertex meshes
    public bool isOn = true;
    [SerializeField] private Transform parentTransform;
    private HashSet<Vector3> spawnedPoints = new HashSet<Vector3>();

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PrivacyRisk"))
        {
            MeshFilter meshFilter = other.GetComponent<MeshFilter>();
            if (meshFilter != null && meshFilter.mesh != null && isOn)
            {
                if (meshFilter.mesh.vertexCount < 50) // Detects primitives and low-vertex meshes
                {
                    StartCoroutine(SpawnSpheresOnBoundingBox(other, transform.position));
                }
                else
                {
                    StartCoroutine(SpawnSpheresAtVertices(meshFilter, transform.position));
                }
            }
        }
    }

    /// <summary>
    /// Spawns spheres at the vertices of a high-density mesh.
    /// </summary>
    private IEnumerator SpawnSpheresAtVertices(MeshFilter meshFilter, Vector3 sensorPosition)
    {
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;
        Vector3 localSensorPosition = meshFilter.transform.InverseTransformPoint(sensorPosition);

        foreach (Vector3 vertex in vertices)
        {
            float distance = Vector3.Distance(vertex, localSensorPosition);
            if (distance <= radius)
            {
                Vector3 worldPosition = meshFilter.transform.TransformPoint(vertex);

                if (!spawnedPoints.Contains(worldPosition))
                {
                    SpawnSphere(worldPosition);
                    spawnedPoints.Add(worldPosition);
                    yield return new WaitForSeconds(spawnDelay);
                }
            }
        }
    }

    /// <summary>
    /// Spawns spheres evenly across a low-density primitive's bounding box.
    /// </summary>
    private IEnumerator SpawnSpheresOnBoundingBox(Collider collider, Vector3 sensorPosition)
    {
        Bounds bounds = collider.bounds;
        Vector3 min = bounds.min;
        Vector3 max = bounds.max;

        for (float x = min.x; x <= max.x; x += gridDensity)
        {
            for (float y = min.y; y <= max.y; y += gridDensity)
            {
                for (float z = min.z; z <= max.z; z += gridDensity)
                {
                    Vector3 point = new Vector3(x, y, z);
                    float distance = Vector3.Distance(point, sensorPosition);

                    if (distance <= radius && !spawnedPoints.Contains(point))
                    {
                        SpawnSphere(point);
                        spawnedPoints.Add(point);
                        yield return new WaitForSeconds(spawnDelay);
                    }
                }
            }
        }
    }

    private void SpawnSphere(Vector3 position)
    {
        if (spherePrefab != null)
        {
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);

            if (parentTransform != null)
            {
                sphere.transform.SetParent(parentTransform);
            }
        }
        else
        {
            Debug.LogWarning("Sphere prefab is not assigned!");
        }
    }

    public void ToggleOn()
    {
        isOn = true;
    }

    public void ToggleOff()
    {
        isOn = false;
    }
}
