using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpace : MonoBehaviour
{
    public float targetX;
    public float targetY;

    public int buildSize = 1;
    public int blocked = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (buildSize == 1)
        {
            MoveSmall();
        }


        if (buildSize == 2)
        {
            MoveMedium();
        }


        if (buildSize == 3)
        {
            MoveLarge();
        }
    }




    void MoveSmall()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
        targetX = Mathf.RoundToInt(worldPoint2d.x);
        targetY = Mathf.RoundToInt(worldPoint2d.y);
        Vector2 position = transform.position;

        if (targetX < CameraScript.WorldSize && targetX > 0 && targetY < CameraScript.WorldSize && targetY > 0)
        {
            position.x = targetX;
            position.y = targetY;
            transform.position = position;
        }
        else
        {
            position.x = -100;
            position.y = -100;
            transform.position = position;
        }
    }

    void MoveMedium()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
        targetX = Mathf.RoundToInt(worldPoint2d.x) + .5f;
        targetY = Mathf.RoundToInt(worldPoint2d.y) + .5f;
        Vector2 position = transform.position;

        if (targetX < CameraScript.WorldSize - .5f && targetX > 0.5f && targetY < CameraScript.WorldSize - .5f && targetY > 0.5f)
        {
            position.x = targetX;
            position.y = targetY;
            transform.position = position;
        }
        else
        {
            position.x = -100;
            position.y = -100;
            transform.position = position;
        }
    }

    void MoveLarge()
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
        targetX = Mathf.RoundToInt(worldPoint2d.x);
        targetY = Mathf.RoundToInt(worldPoint2d.y);
        Vector2 position = transform.position;

        if (targetX < CameraScript.WorldSize - 2 && targetX > 2 && targetY < CameraScript.WorldSize - 2 && targetY > 2)
        {
            position.x = targetX;
            position.y = targetY;
            transform.position = position;
        }
        else
        {
            position.x = -100;
            position.y = -100;
            transform.position = position;
        }
    }

    public void KillAllExistingOutlines()
    {
        Destroy(gameObject);
    }

}
