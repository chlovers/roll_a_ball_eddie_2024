using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject Keys;
    public GameObject doorway;


    void Start()
    {
        Keys.SetActive(true);
        doorway.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Keys.SetActive(false);
            doorway.SetActive(true);
        }

    }
}
