using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this file isn't doing anything in particular, but holds inventory items that will be stored and accessed by multiple characters

public class ResourceTracker : MonoBehaviour
{
    public static ResourceTracker instance { get; set; }

    //t1
    public int meat = 1;
    public int meatMax = 1;

    public int wheat = 1;
    public int wheatMax = 1;

    public int ore = 1;
    public int oreMax = 1;

    public int wood = 1;
    public int woodMax = 1;

    //research 
    public int scrolls = 1;
    public int books = 1;
    public int grimoire = 1;

    public int number;


    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //these have no reason to be here but need to be SOMEWHERE
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ResourceGain(int number, int resource, int resourceMax)
    {

        if (resource < resourceMax)
        {
            resource = Mathf.Min(resource + number, resourceMax);
            Debug.Log("You gained" + number + " " + resource + "out of a maximum" + resourceMax);
        }
        //   ButtonController.instance.skill = scrolls;
    }


}
