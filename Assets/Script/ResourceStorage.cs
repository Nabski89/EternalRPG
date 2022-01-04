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

}
