using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int stall = 60;
    int RandomNUMBER;
    int attack = 0;
    int block = 0;
    public GameObject AttackPrefab;
    public GameObject BlockPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stall = stall - 1;
        if (stall == 10)
        {
            RandomNUMBER = Random.Range(0, 2);
            if (RandomNUMBER == 0)
            {
                attack = 1;
            }
            else
            {
                block = 1;
            }
        }


        //these objects are being created in their original location, they need to be created in front of the raven and aimed left.
        if (stall == 0)
        {
            if (attack == 1)
            {
                attack = 0;
                GameObject AttackObject = Instantiate(AttackPrefab);
                stall = 60;
            }
            if (block == 1)
            {
                block = 0;
                GameObject BlockObject = Instantiate(BlockPrefab);
                stall = 60;
            }
        }
    }
}
