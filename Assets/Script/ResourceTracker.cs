using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this file isn't doing anything in particular, but holds inventory items that will be stored and accessed by multiple characters

public class ResourceTracker : MonoBehaviour
{
    public static ResourceTracker instance { get; set; }


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


    public void SetValue(float number)
    {
        scrolls = scrolls + 1;

        Debug.Log("Something happened with " + scrolls + " and " + number);
        Debug.Log("You've got this many books:" + books);

     //   ButtonController.instance.skill = scrolls;
    }


}
