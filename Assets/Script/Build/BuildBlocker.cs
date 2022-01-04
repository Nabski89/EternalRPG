using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBlocker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        BuildSpace controllerBuildBlock = other.GetComponent<BuildSpace>();
        if (controllerBuildBlock != null)
        {
            //blocks building
            controllerBuildBlock.blocked = 1;
            Debug.Log("Can't Build Here");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        BuildSpace controllerBuildBlock = other.GetComponent<BuildSpace>();

        if (controllerBuildBlock != null)
        {
            //unblocks building
            controllerBuildBlock.blocked = 0;
        }
    }
}
