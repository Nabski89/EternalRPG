using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEnum : MonoBehaviour
{
    //the point of enum is just to make sure we spell things correctly
    public enum Resource { KnowledgeG1, PictureG2, ScrollG3, BookG4, MeatP1, VinesP2, HerbP3, ExtractP4, BigManaM1, InkM2, OrbM3, ArcanaM4, StoneC1, GoldC2, OreC3, CrystalC4 };
    //Make a dictionary with that type, and a quantity
    public static Dictionary<Resource, int> ResourceDic = new Dictionary<Resource, int>();
    public static Dictionary<Resource, int> ResourceMaxDic = new Dictionary<Resource, int>();

    public GameObject ManaUI;

    void Awake()
    {
        //add everything to the dictionary
        //Group Knowledge Resources
        ResourceDic[Resource.KnowledgeG1] = 3;
        ResourceDic.Add(Resource.PictureG2, 4);
        ResourceDic.Add(Resource.ScrollG3, 5);
        ResourceDic.Add(Resource.BookG4, 6);

        ResourceMaxDic.Add(Resource.KnowledgeG1, 50);
        ResourceMaxDic.Add(Resource.PictureG2, 20);
        ResourceMaxDic.Add(Resource.ScrollG3, 25);
        ResourceMaxDic.Add(Resource.BookG4, 30);

        //Potion Resources
        ResourceDic[Resource.MeatP1] = 3;
        ResourceDic.Add(Resource.VinesP2, 4);
        ResourceDic.Add(Resource.HerbP3, 5);
        ResourceDic.Add(Resource.ExtractP4, 6);

        ResourceMaxDic.Add(Resource.MeatP1, 50);
        ResourceMaxDic.Add(Resource.VinesP2, 20);
        ResourceMaxDic.Add(Resource.HerbP3, 25);
        ResourceMaxDic.Add(Resource.ExtractP4, 30);

        //Magical Resources, Names and theming are currently WEAK
        ResourceDic[Resource.BigManaM1] = 3;
        ResourceDic.Add(Resource.InkM2, 4);
        ResourceDic.Add(Resource.OrbM3, 5);
        ResourceDic.Add(Resource.ArcanaM4, 6);

        ResourceMaxDic.Add(Resource.BigManaM1, 50);
        ResourceMaxDic.Add(Resource.InkM2, 20);
        ResourceMaxDic.Add(Resource.OrbM3, 25);
        ResourceMaxDic.Add(Resource.ArcanaM4, 30);

        //Ore Resources
        ResourceDic[Resource.StoneC1] = 3;
        ResourceDic.Add(Resource.GoldC2, 4);
        ResourceDic.Add(Resource.OreC3, 5);
        ResourceDic.Add(Resource.CrystalC4, 6);

        ResourceMaxDic.Add(Resource.StoneC1, 50);
        ResourceMaxDic.Add(Resource.GoldC2, 20);
        ResourceMaxDic.Add(Resource.OreC3, 25);
        ResourceMaxDic.Add(Resource.CrystalC4, 30);
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
    // Mana is special because it is going to be changing every frame and we don't want to update EVERYTHING every frame
//    public void ManaChange()
//    {
//        ManaUI.ResourceUpdate();
//    }
}