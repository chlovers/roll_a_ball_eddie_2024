using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treebehavour : MonoBehaviour
{
    public GameObject poweruptext;
    public GameObject Tree;
    // Start is called before the first frame update
    void Start()
    {
        Tree.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if  (poweruptext.activeSelf)
            {
                Tree.SetActive(false);
            }
        }
    }

}
