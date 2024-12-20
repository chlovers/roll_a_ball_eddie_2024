using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public float speed = 5.0f;
    public float climbSpeed = 3.0f;
    private bool isClimbing = false;
    public float maxspeed = 10f;
    public Camera playerCamera; // Reference to the camera

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 5.0f, 0.0f);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            Vector3 climbMovement = new Vector3(0.0f, movementY, 0.0f);
            rb.velocity = new Vector3(rb.velocity.x, climbMovement.y * climbSpeed, rb.velocity.z);
        }
        else
        {
            Vector3 cameraForward = playerCamera.transform.forward;
            Vector3 cameraRight = playerCamera.transform.right;

            
            cameraForward.y = 0;
            cameraRight.y = 0;
            cameraForward.Normalize();
            cameraRight.Normalize();

            Vector3 movement = cameraForward * movementY + cameraRight * movementX;

           
            rb.AddForce(movement * speed);

           
            if (rb.velocity.magnitude > maxspeed)
            {
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            isClimbing = true;
            rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            isClimbing = false;
            rb.useGravity = true;
        }
    }
}