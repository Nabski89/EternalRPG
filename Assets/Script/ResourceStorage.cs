using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceStorage : MonoBehaviour
{
    public int MaxIncrease = 3;
    public ResourceEnum.Resource ResourceType;


    void Awake()
    {
    }

    void Start()
    {
        ResourceEnum.ResourceChangeMax(ResourceType, MaxIncrease);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("Pressed primary button.");
            ResourceEnum.ResourceChangeMax(ResourceType, -MaxIncrease);

            Destroy(gameObject);
        }
    }
}
