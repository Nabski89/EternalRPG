using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this file isn't doing anything in particular, but holds inventory items that will be stored and accessed by multiple characters
//

public class ResourceTracker : MonoBehaviour
{
    public static ResourceTracker instance { get; set; }

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
}
