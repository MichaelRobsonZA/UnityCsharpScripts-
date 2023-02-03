using UnityEngine;

public class InputController : MonoBehaviour
{
    // The character controller component
    private CharacterController characterController;

    // The movement speed
    public float movementSpeed = 5f;

    // The tilt sensitivity
    public float tiltSensitivity = 1f;

    // The touch sensitivity
    public float touchSensitivity = 0.1f;

    void Start()
    {
        // Get the character controller component
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Get the horizontal and vertical input from touch or tilt
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // If the device is tilted, multiply the input by the tilt sensitivity
        if (Input.deviceOrientation == DeviceOrientation.LandscapeLeft || Input.deviceOrientation == DeviceOrientation.LandscapeRight)
        {
            horizontalInput *= tiltSensitivity;
            verticalInput *= tiltSensitivity;
        }
        // If the device is touched, multiply the input by the touch sensitivity
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            horizontalInput = touch.deltaPosition.x * touchSensitivity;
            verticalInput = touch.deltaPosition.y * touchSensitivity;
        }

        // Calculate the movement vector
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = transform.TransformDirection(movement);
        movement *= movementSpeed * Time.deltaTime;

        // Move the character
        characterController.Move(movement);
    }
}
