using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 5f; // Default speed
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Button;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public Camera playercam;

    private float xRotation = 0f; // Variable for camera rotation
    public float sensitivity = 2.0f; // Mouse sensitivity

    void Start()
    {
        count = 0;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        SetCountText();

        winTextObject.SetActive(false);
        Button.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
    }

    private void FixedUpdate()
    {
        Vector3 forward = playercam.transform.forward;
        Vector3 right = playercam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 movement = (right * movementX + forward * movementY).normalized;

        rb.AddForce(movement * speed);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Button.SetActive(true);
        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {
        // Handle jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Handle mouse look
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Clamp and apply vertical rotation to the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playercam.transform.localRotation = Quaternion.Euler(xRotation, playercam.transform.localEulerAngles.y, 0f);

        // Rotate the player body
        transform.Rotate(Vector3.up * mouseX);
    }
}