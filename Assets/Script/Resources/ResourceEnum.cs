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

    public UIResources ManaUI;
    public int ManaDecay = 60;
    public int ManaDecayCounter = 0;

    void Awake()
    {
        
        //add everything to the dictionary
        //Group Knowledge Resources
        ResourceDic[Resource.KnowledgeG1] = 0;
        ResourceDic.Add(Resource.PictureG2, 0);
        ResourceDic.Add(Resource.ScrollG3, 0);
        ResourceDic.Add(Resource.BookG4, 0);

        ResourceMaxDic.Add(Resource.KnowledgeG1, 5);
        ResourceMaxDic.Add(Resource.PictureG2, 4);
        ResourceMaxDic.Add(Resource.ScrollG3, 3);
        ResourceMaxDic.Add(Resource.BookG4, 2);

        //Potion Resources
        ResourceDic[Resource.MeatP1] = 2;
        ResourceDic.Add(Resource.VinesP2, 0);
        ResourceDic.Add(Resource.HerbP3, 0);
        ResourceDic.Add(Resource.ExtractP4, 0);

        ResourceMaxDic.Add(Resource.MeatP1, 6);
        ResourceMaxDic.Add(Resource.VinesP2, 3);
        ResourceMaxDic.Add(Resource.HerbP3, 1);
        ResourceMaxDic.Add(Resource.ExtractP4, 1);

        //Magical Resources, Names and theming are currently WEAK
        ResourceDic[Resource.BigManaM1] = 2;
        ResourceDic.Add(Resource.InkM2, 0);
        ResourceDic.Add(Resource.OrbM3, 0);
        ResourceDic.Add(Resource.ArcanaM4, 0);

        ResourceMaxDic.Add(Resource.BigManaM1, 5);
        ResourceMaxDic.Add(Resource.InkM2, 0);
        ResourceMaxDic.Add(Resource.OrbM3, 0);
        ResourceMaxDic.Add(Resource.ArcanaM4, 0);

        //Ore Resources
        ResourceDic[Resource.StoneC1] = 0;
        ResourceDic.Add(Resource.GoldC2, 0);
        ResourceDic.Add(Resource.OreC3, 0);
        ResourceDic.Add(Resource.CrystalC4, 0);

        ResourceMaxDic.Add(Resource.StoneC1, 0);
        ResourceMaxDic.Add(Resource.GoldC2, 0);
        ResourceMaxDic.Add(Resource.OreC3, 0);
        ResourceMaxDic.Add(Resource.CrystalC4, 0);
    }

    public static void ResourceChangeAmount(Resource TYPE, int number)
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
    void Update()
    {
        ManaDecayCounter += 1;
        if (ManaDecayCounter >= ManaDecay)
        {
            ResourceDic[Resource.BigManaM1] = Mathf.Max((ResourceDic[Resource.BigManaM1] - 1), 0);
            ManaDecayCounter = 0;
            ManaUI.ResourceUpdate();
        }
    }
    // Mana is special because it is going to be changing every frame and we don't want to update EVERYTHING every frame
    //    public void ManaChange()
    //    {
    //        ManaUI.ResourceUpdate();
    //    }
}