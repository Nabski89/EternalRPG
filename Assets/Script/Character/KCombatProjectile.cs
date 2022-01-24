using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KCombatProjectile : MonoBehaviour
{
    //shoot forward
    //base attributes off the attacker and some other stuff
    //call the change health script
    public float damageValue = 2;
    public float debuffValue = .2f / 30f;
    public float direction = -1f;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("An Allied Attack Has Fired");
        Destroy(gameObject, 5);


        go();
    }
    public Rigidbody2D rb;
    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void go()
    {
        KoboldCombatController CombatController = GetComponentInParent<KoboldCombatController>();
        //still need to apply a uniform speed modifier on this with CombatController.VelocityTarget
        Vector2 position = transform.position;
        rb.velocity = Vector3.right;
        // (CombatController.VecTarget - transform.position)/500;

        Debug.Log(CombatController.VecTarget);
    }
    //tries to call info from the parent
    //I don't remember where this was being used if ever
    public void SetValues(float Attack, string TYPE1, float Attack2, string TYPE2, float FIRE)
    {
        if (TYPE1 == "DAMAGE")
        {
            damageValue = Attack;
        }
        if (TYPE2 == "DAMAGE")
        {
            damageValue = damageValue + Attack2;
        }
        direction = FIRE;
    }
    // Update is called once per frame
    public void OnTriggerEnter2D(Collider2D other)
    {
        EnemyController Econtroller = other.GetComponent<EnemyController>();

        if (Econtroller != null)
        {
            Econtroller.updateLife(-3);
            Destroy(gameObject);
            Debug.Log("You have hit an enemy with an attack");
        }
    }
    public void Blocked(float shieldValue)
    {
        if (damageValue <= 0)
            Destroy(gameObject);
    }
}