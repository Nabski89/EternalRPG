using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEnum : MonoBehaviour
{
    //the point of enum is just to make sure we spell things correctly
    public enum T1Resource { Meat, Wheat, Stone, Wood };
    //Make a dictionary with that type, and a quantity
    public static Dictionary<T1Resource, int> T1Dic = new Dictionary<T1Resource, int>();
    public static Dictionary<T1Resource, int> T1MaxDic = new Dictionary<T1Resource, int>();
 
    void Awake()
    {
        //add everything to the dictionary
        T1Dic[T1Resource.Meat] = 3;
        T1Dic.Add(T1Resource.Wheat, 4);
        T1Dic.Add(T1Resource.Stone, 5);
        T1Dic.Add(T1Resource.Wood, 6);

        T1MaxDic.Add(T1Resource.Meat, 50);
        T1MaxDic.Add(T1Resource.Wheat, 20);
        T1MaxDic.Add(T1Resource.Stone, 25);
        T1MaxDic.Add(T1Resource.Wood, 30);
    }
    int t1resourceTOBECHANGED = 2;
    int t1resourceTOBECHANGEDMAX = 2;

/*    public void ResourceGain(T1Resource TYPE, T1ResourceMAX TYPEMAX, int number)
    {
//        t1resourceTOBECHANGED = TYPE;
//      t1resourceTOBECHANGEDMAX = TYPEMAX;
        if (t1resourceTOBECHANGED < t1resourceTOBECHANGEDMAX)
        {
            t1resourceTOBECHANGED = Mathf.Min(t1resourceTOBECHANGED + number, t1resourceTOBECHANGEDMAX);
        }
        UIResources.instance.ResourceUpdate(t1resourceTOBECHANGED, t1resourceTOBECHANGEDMAX);

    } */

    void Update()
    {
        //    t1resource = t1resource + 1;

        //     Input NEED TO FIGURE OUT DICTIONARIES
    }
}