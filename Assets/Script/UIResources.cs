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
    public Text UIMeat;
    public Text UIMeatMax;
    public static int Meatnottext = 60;
    public static int MeatMaxnottext = 400;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UIMeatMax.text = MeatMaxnottext.ToString();
        UIMeat.text = Meatnottext.ToString();
    }
    public void MEATY() //SetValue(float value)
    {
        MeatMaxnottext += 1;
        UIMeat.text = Meatnottext.ToString();
        UIMeatMax.text = MeatMaxnottext.ToString();
    } 
}