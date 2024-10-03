using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerstage2: MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public GameObject burn;
    public GameObject poweruptext;


    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        rb = GetComponent<Rigidbody>();

        SetCountText();

        winTextObject.SetActive(false);

        burn.SetActive(false);

        poweruptext.SetActive(false);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
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

        if (other.gameObject.CompareTag("Powerup"))
        {
            other.gameObject.SetActive(false);
            poweruptext.SetActive(true);
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

        if (count == 12)
        {
            
            burn.SetActive(true);
        }

        if (count == 20)
        {
            winTextObject.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

}
