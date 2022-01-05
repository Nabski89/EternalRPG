using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorderStorage : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Example());



    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(1);
        print(Time.time);
        foreach (var Camera in GameObject.FindObjectsOfType<CameraScript>())
        {
            Camera.GrowWorld(true);
            Debug.Log("CAMERA TELEPORT ACTIVATE");
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            foreach (var Camera in GameObject.FindObjectsOfType<CameraScript>())
            {
                Camera.GrowWorld(false);
                Debug.Log("CAMERA TELEPORT ACTIVATE");
            }
            Destroy(gameObject);

        }
    }
}