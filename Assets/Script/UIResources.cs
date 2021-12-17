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
    public Text UIText;
    public ResourceEnum.T1Resource ResourceType;
    public static int ResourceValue = 2;
    public static int ResourceValueMax = 3;

    //start goes AFTER awake
    void Start()
    {
        ResourceValue = ResourceEnum.T1Dic[ResourceType];
        ResourceValueMax = ResourceEnum.T1MaxDic[ResourceType];

        UIText.text = ResourceValue.ToString() + " / "+ ResourceValueMax.ToString();
    }
    public void ResourceUpdate()
    {
//        Debug.Log("Dictionary Value" + ResourceEnum.T1Dic[ResourceType]);

        ResourceValue = ResourceEnum.T1Dic[ResourceType];
//        Debug.Log("Resource value " + ResourceValue);

        ResourceValueMax = ResourceEnum.T1MaxDic[ResourceType];

        UIText.text = ResourceValue.ToString() + " / "+ ResourceValueMax.ToString();
    }
}