using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float WorldSize = 40;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 position = transform.position;
            //need to add a constant to the 0 and 100 to keep things in frame, something like 135/6
            position.x = Mathf.Clamp(position.x + 10f * horizontal * Time.deltaTime, 0 + 13.5f, WorldSize - 17.5f);
            position.y = Mathf.Clamp(position.y + 10f * vertical * Time.deltaTime, 0 + 6, WorldSize - 10);
            transform.position = position;
    }
//add 13.5 amount to X
//add 6 to y
    public void TeleportToArea(int Area, int CombatArea)
    {
        Debug.Log("CAMERA TELEPORT ACTIVATE");

        Vector3 position = transform.position;
        position.x = (CombatArea * 50f) + 13.5f;
        if (CombatArea == 1)
        {
            position.y = 30;
        }
        else
        {
            position.y = 0;
        }
        transform.position = position;
    }
}
