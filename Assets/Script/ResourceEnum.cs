using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEnum : MonoBehaviour
{
    //the point of enum is just to make sure we spell things correctly
    public enum Resource { Gold, Knowledge, Meat, Stone, Wood, Herb, Scroll, Ore, Extract, Gem, Codex, MagicOre, Crystal };
    //Make a dictionary with that type, and a quantity
    public static Dictionary<Resource, int> ResourceDic = new Dictionary<Resource, int>();
    public static Dictionary<Resource, int> ResourceMaxDic = new Dictionary<Resource, int>();

    void Awake()
    {
        //add everything to the dictionary
        ResourceDic[Resource.Meat] = 3;
        ResourceDic.Add(Resource.Wheat, 4);
        ResourceDic.Add(Resource.Stone, 5);
        ResourceDic.Add(Resource.Wood, 6);

        ResourceMaxDic.Add(Resource.Meat, 50);
        ResourceMaxDic.Add(Resource.Wheat, 20);
        ResourceMaxDic.Add(Resource.Stone, 25);
        ResourceMaxDic.Add(Resource.Wood, 30);

        ResourceDic.Add(Resource.Gold, 0);
        ResourceMaxDic.Add(Resource.Gold, 50);

        ResourceDic.Add(Resource.Knowledge, 0);
        ResourceMaxDic.Add(Resource.Knowledge, 50);

        ResourceMaxDic.Add(Resource.Stone, 25);
        ResourceMaxDic.Add(Resource.Wood, 30);

        ResourceMaxDic.Add(Resource.Stone, 25);
        ResourceMaxDic.Add(Resource.Wood, 30);

        ResourceMaxDic.Add(Resource.Stone, 25);
        ResourceMaxDic.Add(Resource.Wood, 30);
        
        
    }
    public static void ResourceChange(Resource TYPE, int number)
    {
        ResourceDic[TYPE] = Mathf.Clamp(ResourceDic[TYPE] + number, 0, ResourceMaxDic[TYPE]);
        ResourceChange();
    }

    public static void ResourceChangeMax(Resource TYPE, int number)
    {
        ResourceMaxDic[TYPE] = Mathf.Clamp((ResourceMaxDic[TYPE] + number), 0, 999);
        ResourceDic[TYPE] = Mathf.Clamp(ResourceDic[TYPE], 0, ResourceMaxDic[TYPE]);
        ResourceChange();
    }

    public static void ResourceChange()
    {
        //finds everything that has a UI resource script attached, and then runs the script on all of them
        foreach (var resource in GameObject.FindObjectsOfType<UIResources>())
        {
            resource.ResourceUpdate();
        }
    }
}