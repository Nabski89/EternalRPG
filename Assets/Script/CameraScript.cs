using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TeleportToArea(int Area, int CombatArea)
    {
        Debug.Log("CAMERA TELEPORT ACTIVATE");

        Vector3 position = transform.position;
        position.x = CombatArea * 40;
        if (CombatArea == 1)
        {
            position.y = 25;
        }
        else
        {
            position.y = 0;
        }
        transform.position = position;
    }
}
