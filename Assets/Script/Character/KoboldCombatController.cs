using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldCombatController : MonoBehaviour
{
    public GameObject Kobold;
    public GameObject AttackPrefab;
    public GameObject BuffPrefab;
    public GameObject BlockPrefab;
    bool Buffed = false;
    float TarX;
    float TarY;
    float CalcX;
    float CalcY;

    public Vector3 VecTarget;
    public float VelocityMod;
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
            Attack();

        }
        //block, slot 2
        if (Input.GetKeyDown(KeyCode.Y))
        {

        }
        //buff, slot 3
        if (Input.GetKeyDown(KeyCode.U))
        {
            //            Kobold.KoboldController.ChangeHealth(3f);
            //just do something to buff an ability?
        }

    }


    public void Attack()
    {
        TarX = 100;
        TarY = 100;
        foreach (var EnemyController in GameObject.FindObjectsOfType<EnemyController>())
        {
            Vector2 Eposition = EnemyController.transform.position;
            Vector2 KPosition = transform.position;
            CalcX = Mathf.Abs(Eposition.x - KPosition.x);
            CalcY = Mathf.Abs(Eposition.y - KPosition.y);
            if ((CalcX + CalcY) < (Mathf.Abs(TarX) + Mathf.Abs(TarY)))
            {
                TarX = Eposition.x;
                TarY = Eposition.y;
            }
        Debug.Log(TarX + " " + TarY + "fight me");
        }
        if (TarX != 100)
        {
            VecTarget.x = TarX;
            VecTarget.y = TarY;
            //          VelocityMod = 1 / (Mathf.Sqrt((TarX * TarX) + (TarY * TarY)));
            GameObject childGameObject = Instantiate(AttackPrefab, this.transform);
            childGameObject.name = "Attack";
        }
    }

    void Block()
    {
        GameObject childGameObject = Instantiate(BlockPrefab, this.transform);
        childGameObject.name = "Block";
    }

    void Buff()
    {
        Buffed = true;
    }

    void Debuff()
    {

    }

}