using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldEquipment : MonoBehaviour
{

    //haven't decided how this is going to be done yet
    // I'm currently thinking
    //one item, that gives job capabilities
    //one armor that gives ????
    // five misc items, like armor that is unused

    //or maybe just four total items, and have some kind of "swap to other armor" thing, maybe enabled at higher levels so I can have an excuse to not deal with it right now.

    //do I do all the things it can do as some kind of enum list?
    //yeah I do

    public enum Tools { PenValue, HerbValue, WandValue, PickValue, HammerValue }; //craft better book, craft potion types, magic improvements, improve chances of what you get out of mine, change what you will craft
    public enum Gear { Amulet, Hat, Backpack } //I have no idea what these are going to do, they are for non crafting things.

    public Dictionary<Tools, float> ToolDic = new Dictionary<Tools, float>();
    public Dictionary<Gear, float> GearDic = new Dictionary<Gear, float>();

    public bool HaveTool = false;
    public bool HaveGear = false;


    // Start is called before the first frame update
    void Start()
    {
        ZeroEquipTool();
        ZeroEquipGear();
    }

    void ZeroEquipTool()
    {
        ToolDic[Tools.PenValue] = 0;
        ToolDic[Tools.HerbValue] = 0;
        ToolDic[Tools.WandValue] = 0;
        ToolDic[Tools.PickValue] = 0;
        ToolDic[Tools.HammerValue] = 0;
    }

    void ZeroEquipGear()
    {
        GearDic[Gear.Amulet] = 0;
        GearDic[Gear.Hat] = 0;
        GearDic[Gear.Backpack] = 0;
    }
    void EquipTool()
    {
        HaveTool = true;
    }
    void EqipGear()
    {
        HaveGear = true;
    }
    void UnequipTool()
    {
        HaveTool = false;
        //set values to 0
    }
    void UnequipGear()
    {
        HaveGear = false;
        //set values to 0
    }

    //    https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
}
