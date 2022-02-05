using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomBase : MonoBehaviour
{
    public bool Room = true;

    void awake()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        RoomOffshoot RoomHit = other.GetComponent<RoomOffshoot>();

        if (RoomHit != null)
        {
            Debug.Log("There should be a doorway");
            Destroy(RoomHit);
        }
    }
}
