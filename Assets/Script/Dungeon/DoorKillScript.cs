using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKillScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
Destroy(gameObject,30);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Door DoorHit = other.GetComponent<Door>();

        if (DoorHit != null)
        {

            Debug.Log("There should be a doorway");
            Destroy(DoorHit.gameObject);
            Debug.Log("Why am I not dead?");
        }
    }
}
