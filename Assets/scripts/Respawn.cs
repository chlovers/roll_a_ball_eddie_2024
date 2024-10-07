using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    public Transform SpawnPoint;
    public float threshold;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            player.transform.position = SpawnPoint.transform.position;
        }
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
            transform.position = new Vector3(0, 0, 0);
    }
}
