using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public CameraScript CameraScript;
    // GameObject objectWithScript;

    // objectWithScript.TeleportToArea();

    public int Area = 0;
    public int CombatArea = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        ButtonController controller = other.GetComponent<ButtonController>();

        if (controller != null)

        {
            Debug.Log("You have entered the FIGHT ZONE");

        }
        controller.TeleportToArea(Area, CombatArea);
        CameraScript.TeleportToArea(Area, CombatArea);
    }
}



/* This is some movement code, camera has to move as a vector 3
            Vector2 position = transform.position;
            position.x = CombatArea * 40;
            position.y = 0;
            if (CombatArea > 1);
            {
            position.y = 25;
            }
            transform.position = position;


            */