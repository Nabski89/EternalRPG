using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this file isn't doing anything in particular, but holds inventory items that will be stored and accessed by multiple characters

public class ResourceTracker : MonoBehaviour
{
    public static ResourceTracker instance { get; set; }

    //t1
    public int meat = 1;
    public int meatMax = 50;

    public int wheat = 1;
    public int wheatMax = 3;

    public int ore = 1;
    public int oreMax = 3;

    public int wood = 1;
    public int woodMax = 3;

    //research 
    public int scrolls = 1;
    public int books = 1;
    public int grimoire = 1;

    public int number;


    void Awake()
    {
        instance = this;

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Start is called before the first frame update
    void Start()
    {
        //these have no reason to be here but need to be SOMEWHERE

        UIResources.instance.ResourceUpdate(meat, meatMax);
    }

    /*   // Update is called once per frame
       void Update()
       {

       }
   */

    //checks if you've got below your max resources, and updates the UI
    public void ResourceGain(int number, int resourcetype)
    {
        resourcetype = 0; //this will be used if we mana to set things into an enum list?
        if (meat < meatMax)
        {
            meat = Mathf.Min(meat + number, meatMax);
        }
        UIResources.instance.ResourceUpdate(meat, meatMax);

    }

    //For changing the max amount something can hold. Updates to max if needed.
    public void ResourceMaxChange(int number, int resourcetype)
    {
        meatMax = meatMax + number;
        if (meatMax < meat)
        {
            meat = meatMax;
        }
        UIResources.instance.ResourceUpdate(meat, meatMax);
    }
}
