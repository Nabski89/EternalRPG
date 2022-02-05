using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOffshoot : MonoBehaviour
{


    public GameObject DOORKILLER;
    void Start()
    {
        Destroy(gameObject, 30);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        RoomBase RoomHit = other.GetComponent<RoomBase>();

        if (RoomHit != null)
        {

            Debug.Log("There should be a doorway");
            Destroy(gameObject);
            Debug.Log("Why am I not dead?");
        }
    }
    public void DoorKill()
    {
        Instantiate(DOORKILLER, new Vector3((transform.position.x + transform.parent.position.x) / 2, (transform.position.y + transform.parent.position.y) / 2, 0), Quaternion.identity, transform);

    }
}
