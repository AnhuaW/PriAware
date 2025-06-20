using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    public float turnSpeed = 2f;

    private bool movingTowardsB = true;
    private bool isTurning = false;

    void Update()
    {
        if (!isTurning)
        {
            Vector3 targetPos = movingTowardsB ? pointB.position : pointA.position;
            Vector3 moveDirection = (targetPos - transform.position).normalized;

            // Move towards the target
            transform.position += moveDirection * speed * Time.deltaTime;

            // Check if close enough to start turning
            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isTurning = true;
            }
        }
        else
        {
            Vector3 nextTarget = movingTowardsB ? pointA.position : pointB.position;
            Vector3 dirToNextTarget = (nextTarget - transform.position).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(dirToNextTarget);

            // Rotate smoothly towards the next target
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 1f)
            {
                isTurning = false;
                movingTowardsB = !movingTowardsB;
            }
        }
    }
}
