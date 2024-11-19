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
    public float climbSpeed = 3.0f;
    private bool isClimbing = false;
    public float maxspeed = 10f;

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
            
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);
            rb.AddForce(movement * speed);
        }

        if (rb.velocity.magnitude > maxspeed)
        {

            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxspeed);
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