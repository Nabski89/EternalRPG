using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIResources : MonoBehaviour
{
    //static means it's accessable from anything else using those same values and all uses the same memory space
    //    public static UIResources instance { get; private set; }

    public static UIResources instance { get; set; }

    //making these public lets you set them in the inspector
    public Text UIText;
    public Text UITextMax;
    public ResourceEnum.T1Resource ResourceType;
    public static int ResourceValue = 2;
    public static int ResourceValueMax = 3;
    
    //start goes AFTER awake
    void Start()
    {
        instance = this;

        ResourceValue = ResourceEnum.T1Dic[ResourceType];
        ResourceValueMax = ResourceEnum.T1MaxDic[ResourceType];

        UIText.text = ResourceValue.ToString();
        UITextMax.text = ResourceValueMax.ToString();
    }
    public void ResourceUpdate() //SetValue(float value)
    {
        ResourceValue = ResourceEnum.T1Dic[ResourceType];
        ResourceValueMax = ResourceEnum.T1MaxDic[ResourceType];

        UIText.text = ResourceValue.ToString();
        UITextMax.text = ResourceValueMax.ToString();
    }
}