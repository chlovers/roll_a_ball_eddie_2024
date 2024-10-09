using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playermovement : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject Button;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public Camera playercam;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        SetCountText();

        winTextObject.SetActive(false);

        Button.SetActive(false);
       
       
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
            count = count + 1;
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

}
