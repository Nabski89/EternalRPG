using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildOnBuild : MonoBehaviour
{

    //four public resources that make up the cost
    public ResourceEnum.Resource ResourceType1;
    public ResourceEnum.Resource ResourceType2;
    public ResourceEnum.Resource ResourceType3;
    public ResourceEnum.Resource ResourceType4;
    public ResourceEnum.Resource ResourceType5;

    //what the resource costs
    public int ResourceCost1;
    public int ResourceCost2;
    public int ResourceCost3;
    public int ResourceCost4;
    public int ResourceCost5;
    public int BUILDINGSIZE;

    public bool buildable = true;

    // Start is called before the first frame update
    void Start()
    {
        //check to make sure we have the resources required to build it, if we do then subtract the cost, if not then destroy it.

        if (ResourceCost1 > ResourceEnum.ResourceDic[ResourceType1])
        {
            buildable = false;
        }
        if (ResourceCost2 > ResourceEnum.ResourceDic[ResourceType2])
        {
            buildable = false;
        }
        if (ResourceCost3 > ResourceEnum.ResourceDic[ResourceType3])
        {
            buildable = false;
        }
        if (ResourceCost4 > ResourceEnum.ResourceDic[ResourceType4])
        {
            buildable = false;
        }
        if (ResourceCost5 > ResourceEnum.ResourceDic[ResourceType5])
        {
            buildable = false;
        }
        if (buildable == true)
        {
            ResourceEnum.ResourceDic[ResourceType1] -= ResourceCost1;
            ResourceEnum.ResourceDic[ResourceType2] -= ResourceCost2;
            ResourceEnum.ResourceDic[ResourceType3] -= ResourceCost3;
            ResourceEnum.ResourceDic[ResourceType4] -= ResourceCost4;
            ResourceEnum.ResourceDic[ResourceType5] -= ResourceCost5;
        }
        if (buildable == false)
        {
            Destroy(gameObject);
        }
    }
}
