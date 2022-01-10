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
    public enum Gear { Amulet, Hat, Backpack } //I have no idea what these are going to do

    public bool HaveWeapon = false;
    public bool HaveArmor = false;


    // Start is called before the first frame update
    void Start()
    {

    }
    void UnequipTool()
    {

    }
    void UnequipGear()
    {

    }

    //    https://www.c-sharpcorner.com/article/loop-through-enum-values-in-c-sharp/
}
