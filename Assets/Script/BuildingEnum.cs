using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingEnum : MonoBehaviour
{
    public GameObject MeatBuilding;
    public GameObject WheatBuilding;
    public GameObject StoneBuilding;
    public GameObject WoodBuilding;

    public enum BuildingGameObject { Meat, Wheat, Stone, Wood };

    public static Dictionary<BuildingGameObject, GameObject> BuildObjectDic = new Dictionary<BuildingGameObject, GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
