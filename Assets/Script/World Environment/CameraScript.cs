using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public static float WorldSizeX = 31+50;
    public static float WorldSizeY = 16+50;
    public static float WorldSizeBuffer = 1;
    public GameObject TopObject;
    public GameObject RightObject;
    public int Counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 position = transform.position;
        //need to add a constant to the 0 and 100 to keep things in frame, something like 135/6
        position.x = Mathf.Clamp(position.x + 10f * horizontal * Time.deltaTime, 0 + 13.5f, WorldSizeX - 17.5f + WorldSizeBuffer);
        position.y = Mathf.Clamp(position.y + 10f * vertical * Time.deltaTime, 0 + 6, WorldSizeY - 10 + WorldSizeBuffer);
        transform.position = position;
    }
    //add 13.5 amount to X
    //add 6 to y

    //We aren't using this anymore
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

    public void GrowWorld(bool DoWeGrow)
    {
        Debug.Log("TRYING TO CHANGE WORLD SIZE");
        if (DoWeGrow == true)
        {
            WorldSizeX += .8f;
            WorldSizeY += .6f;

            foreach (var edge in GameObject.FindObjectsOfType<WorldEdgeMove>())
            {
                edge.move(.8f, .6f);
            }
        }
        else
        {
            WorldSizeX += -.8f;
            WorldSizeY += -.6f;

            foreach (var edge in GameObject.FindObjectsOfType<WorldEdgeMove>())
            {
                edge.move(-.8f, -.6f);
            }
        }

    }
}
