using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform target; // The target to follow
    public float smoothSpeed = 0.125f; // The speed at which the camera moves
    public Vector3 offset; // The offset from the target

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; // Calculate the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Interpolate between the current and desired positions
        transform.position = smoothedPosition; // Update the camera's position

        transform.LookAt(target); // Look at the target
    }
}
