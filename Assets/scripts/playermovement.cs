using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public float speed = 0;
    public float climbSpeed = 3.0f; // Speed for climbing
    private bool isClimbing = false; // Flag for climbing

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
            // Climbing movement
            Vector3 climbMovement = new Vector3(0.0f, movementY, 0.0f); // Only vertical movement for climbing
            rb.velocity = new Vector3(rb.velocity.x, climbMovement.y * climbSpeed, rb.velocity.z);
        }
        else
        {
            // Regular movement
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }
    }

    void Update()
    {
        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Climbable")) // Ensure your ladder has the "Ladder" tag
        {
            isClimbing = true;
            rb.useGravity = false; // Disable gravity while climbing
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Climbable"))
        {
            isClimbing = false;
            rb.useGravity = true; // Enable gravity again when exiting the ladder
        }
    }
}