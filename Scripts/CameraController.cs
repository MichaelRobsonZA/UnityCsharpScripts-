using UnityEngine;

public class CameraController : MonoBehaviour
{
    // The target object to follow
    public Transform target;

    // The offset from the target
    public Vector3 offset = new Vector3(0, 1.5f, -3f);

    // The damping speed
    public float damping = 5f;

    void LateUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * damping);

        // Look at the target
        transform.LookAt(target);
    }
}
