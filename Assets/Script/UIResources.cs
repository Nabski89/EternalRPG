using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResources : MonoBehaviour
{
    //static means it's accessable from anything else using those same values and all uses the same memory space
    // BUT YOU CAN ONLY HAVE ONE THING THAT IS STATIC
    //    public static UIResources instance { get; private set; }


    //making these public lets you set them in the inspector
    public ResourceEnum.Resource ResourceType;
    public static int ResourceValue = 2;
    public static int ResourceValueMax = 3;

    //start goes AFTER awake
    void Start()
    {
        ResourceValue = ResourceEnum.ResourceDic[ResourceType];
        ResourceValueMax = ResourceEnum.ResourceMaxDic[ResourceType];

        gameObject.GetComponent<Text>().text = ResourceValue.ToString() + " / "+ ResourceValueMax.ToString();
    }
    public void ResourceUpdate()
    {
//        Debug.Log("Dictionary Value" + ResourceEnum.ResourceDic[ResourceType]);

        ResourceValue = ResourceEnum.ResourceDic[ResourceType];
//        Debug.Log("Resource value " + ResourceValue);

        ResourceValueMax = ResourceEnum.ResourceMaxDic[ResourceType];

        gameObject.GetComponent<Text>().text = ResourceValue.ToString() + " / "+ ResourceValueMax.ToString();
    }
}