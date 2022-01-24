using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProjectile : MonoBehaviour
{
    //shoot forward
    //base attributes off the attacker and some other stuff
    //call the change health script
    public float damageValue = 20;
    public float debuffValue = .2f / 30f;
    public float direction = -1f;
    void Awake()
    {
        Debug.Log("An Enemy Attack Has Fired");
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
        EnemyCombatController CombatController = GetComponentInParent<EnemyCombatController>();

        //still need to apply a uniform speed modifier on this with CombatController.VelocityTarget
        Vector2 position = transform.position;
        rb.velocity = (CombatController.VecTarget - transform.position) / 2;

        Debug.Log("Projectile Target Location At" + CombatController.VecTarget);

    }


    //tries to call info from the parent
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
        KoboldController Kcontroller = other.GetComponent<KoboldController>();
        if (Kcontroller != null)
        {
            Kcontroller.ChangeHealth(-20);
            Debug.Log("An Enemy Attack Has Hit A Kobold");
            Destroy(gameObject);
        }
    }
    public void Blocked(float shieldValue)
    {
        if (damageValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
