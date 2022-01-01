using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int stall = 60;
    int RandomNUMBER;
    //we need this to make something a child on spawn
    int attack = 0;
    int block = 0;
    public GameObject AttackPrefab;
    public GameObject BlockPrefab;

    public SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame

    public void CreateEnemy()
    {
        //select the sprite
        //select the location based on how many enemies we have
        //seed the loot pool?
        //set the stats
    }


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

                GameObject childGameObject = Instantiate(AttackPrefab, this.transform);
                childGameObject.name = "Attack";
                stall = 60;
            }
            if (block == 1)
            {
                block = 0;
                GameObject childGameObject = Instantiate(BlockPrefab, this.transform);
                childGameObject.name = "Block";
                stall = 60;
            }
        }
    }
}
