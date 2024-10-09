using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float sensitivity = 2.0f; // Mouse sensitivity

    private float xRotation = 0f;

    void Start()
    {
        offset = transform.position - player.transform.position;
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void LateUpdate()
    {
        // Update camera position based on player position
        transform.position = player.transform.position + offset;

        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Calculate rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit the up/down rotation

        // Rotate the camera
        transform.localRotation = Quaternion.Euler(xRotation, transform.localEulerAngles.y, 0f);
        // Rotate the player body
        player.transform.Rotate(Vector3.up * mouseX);
    }
}