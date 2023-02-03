using System;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // The animator component
    private Animator animator;

    // The movement speed
    public float movementSpeed = 5f;

    // The rotation speed
    public float rotationSpeed = 5f;

    // The input vector
    private Vector3 inputVector;

    void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get the input vector
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.z = Input.GetAxis("Vertical");

        // Normalize the input vector
        if (inputVector.magnitude > 1)
            inputVector.Normalize();

        // Update the animator parameters
        animator.SetFloat("Horizontal", inputVector.x);
        animator.SetFloat("Vertical", inputVector.z);

        // Calculate the movement vector
        Vector3 movement = transform.forward * inputVector.z * movementSpeed * Time.deltaTime;

        // Move the character
        transform.position += movement;

        // Calculate the rotation vector
        Vector3 rotation = new Vector3(0, inputVector.x * rotationSpeed, 0);

        // Rotate the character
        transform.Rotate(rotation);
    }

    internal void Move(Vector3 movement)
    {
        throw new NotImplementedException();
    }
}
