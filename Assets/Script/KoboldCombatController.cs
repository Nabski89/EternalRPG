using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldCombatController : MonoBehaviour
{
    public GameObject Kobold;
    public GameObject AttackPrefab;
    public GameObject BuffPrefab;
    public GameObject BlockPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //temp, replace keys with automatic, or maybe let it be either or
        //attack, slot 1
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject childGameObject = Instantiate(AttackPrefab, this.transform);
            childGameObject.name = "Attack";
        }
        //block, slot 2
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameObject childGameObject = Instantiate(AttackPrefab, this.transform);
            childGameObject.name = "Block";
        }
        //buff, slot 3
        if (Input.GetKeyDown(KeyCode.U))
        {
//            Kobold.KoboldController.ChangeHealth(3f);
            //just do something to buff an ability?
        }

    }
}