using UnityEngine;

public class FloatingMovement : MonoBehaviour
{
    public float floatSpeed = 1f;  // Speed of the floating motion
    public float floatHeight = 0.5f; // Height difference of the floating motion

    private Vector3 startPos;
    private float timeOffset;

    void Start()
    {
        startPos = transform.position;
        timeOffset = Random.Range(0f, 2f * Mathf.PI); // Randomize start phase to avoid synchronization
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed + timeOffset) * floatHeight;
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}