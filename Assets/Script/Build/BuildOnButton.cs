using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOnButton : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject Small;
    public GameObject Medium;
    public GameObject Large;
    public GameObject XLarge;
    //1-2-3-4 for small medium large XL, I should probably do this with a script to read it off the object we are going to spawn but this is quicker.
    public int BuildSize = 1;
    public float targetX;
    public float targetY;
    bool buildready = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void BUILD()
    {
        buildready = true;
        foreach (var BuildSpace in GameObject.FindObjectsOfType<BuildSpace>())
        {
            BuildSpace.KillAllExistingOutlines();
        }
        if (BuildSize == 1)
        {
            Instantiate(Small, new Vector3(-25, -25, 0), Quaternion.identity);
        }
        if (BuildSize == 2)
        {
            Instantiate(Medium, new Vector3(-25, -25, 0), Quaternion.identity);
        }
        if (BuildSize == 3)
        {
            Instantiate(Large, new Vector3(-25, -25, 0), Quaternion.identity);
        }
        if (BuildSize == 4)
        {
            Instantiate(XLarge, new Vector3(-25, -25, 0), Quaternion.identity);
        }
    }

    public void Update()
    {
        if (buildready == true)
        {

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
                targetX = Mathf.RoundToInt(worldPoint2d.x);
                targetY = Mathf.RoundToInt(worldPoint2d.y);

                //click location
                //average it out
                //yes, even the "build resource"
                //destroy a building you clicked on???

                if (targetX < CameraScript.WorldSizeX && targetX > 0 && targetY < CameraScript.WorldSizeY && targetY > 0)
                {
                    foreach (var BuildSpace in GameObject.FindObjectsOfType<BuildSpace>())
                    {
                        if (BuildSpace.blocked == 0)
                        {
                            BuildSpace.KillAllExistingOutlines();
                            GameObject childGameObject = Instantiate(ObjectToSpawn, new Vector3(targetX, targetY, 0), Quaternion.identity);

                            buildready = false;

                            Debug.Log("Can we build it, yes we can");
                        }
                        else { Debug.Log("CAN'T DO THAT BOSS"); }
                    }
                }
            }
        }
    }
}