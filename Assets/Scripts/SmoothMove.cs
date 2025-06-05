using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public Transform pointA;  // Starting position
    public Transform pointB;  // Target position
    public float speed = 2f;  // Speed at which the object moves
    public float turnSpeed = 2f; // Speed at which the object turns

    private float journeyLength;  // The total distance between point A and point B
    private float startTime;  // Time when the movement started
    private bool movingTowardsB = true; // Direction of movement (towards point B)
    private bool isTurning = false; // Whether the object is currently rotating

    void Start()
    {
        // Calculate the distance between the two points
        journeyLength = Vector3.Distance(pointA.position, pointB.position);
        startTime = Time.time; // Start the timer
    }

    void Update()
    {
        // Calculate the distance covered
        float distanceCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distanceCovered / journeyLength;

        // If the object is not turning, move it along the path
        if (!isTurning)
        {
            if (movingTowardsB)
            {
                transform.position = Vector3.Lerp(pointA.position, pointB.position, fractionOfJourney);
            }
            else
            {
                transform.position = Vector3.Lerp(pointB.position, pointA.position, fractionOfJourney);
            }

            // When the object reaches point B or A, trigger rotation
            if (fractionOfJourney > 0.9f)
            {
                isTurning = true;
                startTime = Time.time; // Restart the timer for rotation
            }
        }
        else
        {
            // Smooth rotation towards the target point
            Vector3 targetDirection = movingTowardsB ? pointB.position - transform.position : pointA.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            // If rotation is complete, start moving again
            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isTurning = false; // Rotation done
                movingTowardsB = !movingTowardsB; // Change direction
                startTime = Time.time; // Restart movement timer
            }
        }
    }
}