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
    private bool buildready = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void BUILD()
    {
        buildready = true;
        Debug.Log("The button was pushed");


        if (BuildSize == 1) ;
        {
            Instantiate(Small);
        }
        if (BuildSize == 2) ;
        {
            Instantiate(Medium);
        }
        if (BuildSize == 3) ;
        {
            Instantiate(Large);
        }
        if (BuildSize == 4) ;
        {
            Instantiate(XLarge);
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

                if (targetX < CameraScript.WorldSize && targetX > 0 && targetY < CameraScript.WorldSize && targetY > 0)
                {
                    GameObject childGameObject = Instantiate(ObjectToSpawn, new Vector3(targetX, targetY, 0), Quaternion.identity);

                    buildready = false;
                    Debug.Log("Can we build it, yes we can");
                }
            }
        }
    }
}