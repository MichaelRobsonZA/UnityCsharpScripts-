using UnityEngine;

public class AdvancedHumanoidController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float crouchSpeed = 2f;
    public float jumpForce = 5f;
    public float dashForce = 10f;
    public float dashDuration = 0.5f;

    public Rigidbody myrigidbody;
    private bool isCrouching = false;
    private bool isDashing = false;
    private float dashStartTime;

    private void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);

        float speed = walkSpeed;
        if (Input.GetButton("Run"))
        {
            speed = runSpeed;
        }
        else if (Input.GetButton("Crouch"))
        {
            speed = crouchSpeed;
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if (Input.GetButtonDown("Jump") && !isCrouching)
        {
            myrigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetButtonDown("Dash") && !isCrouching && !isDashing)
        {
            dashStartTime = Time.time;
            isDashing = true;
            myrigidbody.AddForce(movement * dashForce, ForceMode.Impulse);
        }

        if (isDashing && Time.time - dashStartTime > dashDuration)
        {
            isDashing = false;
        }

        if (!isDashing)
        {
            myrigidbody.velocity = movement * speed;
        }
    }

    private void FixedUpdate()
    {
        if (isCrouching)
        {
            Vector3 crouchSlide = Vector3.Cross(transform.forward, Vector3.up);
            myrigidbody.velocity = Vector3.ProjectOnPlane(myrigidbody.velocity, crouchSlide);
        }
    }
}
