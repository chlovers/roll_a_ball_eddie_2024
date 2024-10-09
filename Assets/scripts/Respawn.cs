using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public Transform SpawnPoint;
    public float threshold;
    void OnTriggerEnter(Collider other)
    {
        rb = other.gameObject.GetComponent<Rigidbody>();
       rb.isKinematic = true;
        rb.isKinematic = false;
        
        Debug.Log("respawntest notag");
        other.transform.position = SpawnPoint.transform.position;
        

        if (other.tag == "Player")

        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            Debug.Log("respawntest");
            player.transform.position = SpawnPoint.transform.position;
            rb.isKinematic = false;
        }
    }

   // void FixedUpdate()
  //  {
   //     if (transform.position.y < threshold)
   //         transform.position = new Vector3(0, 0, 0);
  //  }
}
