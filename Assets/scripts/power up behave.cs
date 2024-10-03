using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class powerupbehave : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    public GameObject burn;

    void Start()
    {
        burn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            
          burn.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            burn.gameObject.SetActive(false);
          
        }
    }
}


