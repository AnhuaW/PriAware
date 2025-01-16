using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SensorCollisionHandler : MonoBehaviour
{ 
    public GameObject spherePrefab;
    public float radius = 3f; 
    [SerializeField]private HashSet<Vector3> spawnedPoints = new HashSet<Vector3>();
    [SerializeField] private Transform parentTransform;
    public float spawnDelay = 0.3f;
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PrivacyRisk"))
        {
            Debug.Log(other.gameObject.name + " detected");
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            HighlightCollisionArea(other, collisionPoint);
        }
    }*/

    private void HighlightCollisionArea(Collider collidedObject, Vector3 collisionPoint)
    {
        // Spawn a highlight effect at the collision point
        if (spherePrefab != null)
        {
            GameObject highlight = Instantiate(spherePrefab, collisionPoint, Quaternion.identity);
            highlight.transform.SetParent(collidedObject.transform);
            //Destroy(highlight, 2f);
        }
        else
        {
            Debug.LogWarning("Highlight Prefab is not assigned.");
        }
    }
    
     private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PrivacyRisk"))
        {
            // Continuously update the spatial data collection
            MeshFilter meshFilter = other.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                StartCoroutine(SpawnSpheresAtCollision(meshFilter, transform.position));
            }
        }
    }

    private IEnumerator SpawnSpheresAtCollision(MeshFilter meshFilter, Vector3 sensorPosition)
    {
        // Get mesh and vertices
        Mesh mesh = meshFilter.mesh;
        Vector3[] vertices = mesh.vertices;

        // Convert sensor position to local space
        Vector3 localSensorPosition = meshFilter.transform.InverseTransformPoint(sensorPosition);

        // Iterate over vertices and spawn spheres for untracked points within the radius
        foreach (Vector3 vertex in vertices)
        {
            float distance = Vector3.Distance(vertex, localSensorPosition);
            if (distance <= radius)
            {
                // Convert vertex to world space
                Vector3 worldPosition = meshFilter.transform.TransformPoint(vertex);

                // Avoid spawning spheres at the same position repeatedly
                if (!spawnedPoints.Contains(worldPosition))
                {
                    SpawnSphere(worldPosition);
                    spawnedPoints.Add(worldPosition);
                    yield return new WaitForSeconds(spawnDelay);
                }
            }
        }
    }

    private void SpawnSphere(Vector3 position)
    {
        if (spherePrefab != null)
        {
            GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);

            // Scale the sphere to the desired size
            //sphere.transform.localScale = Vector3.one * sphereScale;

            // parent the sphere for better organization in the hierarchy
            if (parentTransform != null)
            {
                sphere.transform.SetParent(parentTransform);
            }

            // Optional: Destroy the sphere after a certain time to avoid clutter
            // Destroy(sphere, 10f);
        }
        else
        {
            Debug.LogWarning("Sphere prefab is not assigned!");
        }
    }
}

