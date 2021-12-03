using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeatStorage : MonoBehaviour
{
    public static ResourceMeatStorage instance { get; set; }

    public int MaxIncrease = 3;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResourceTracker.instance.ResourceMaxChange(MaxIncrease, 1);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Pressed primary button.");
            ResourceTracker.instance.ResourceMaxChange(-MaxIncrease, 1);
            Destroy(gameObject);
        }
    }

}