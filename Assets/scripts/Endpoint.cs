using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    public GameObject Button;



    void Start()
    {
        Button.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Button.SetActive(true);
            Time.timeScale = 0;
        }
    }


    void Update()
    {
        
    }
}
