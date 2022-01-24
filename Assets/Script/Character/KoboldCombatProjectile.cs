using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldCombatProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    //shoot forward
    //base attributes off the attacker and some other stuff
    //call the change health script
    public float damageValue = 2;
    public float debuffValue = .2f / 30f;
    public float direction = -1f;
    // Start is called before the first frame update
    void Awake()
    {

        Destroy(gameObject, 5);

        Vector2 position = transform.position;
        position.x = position.x + 5f * direction;
        transform.position = position;

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
        rb.velocity = CombatController.VecTarget - transform.position;

        Debug.Log(CombatController.VecTarget);

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
        EnemyHitbox controller = other.GetComponent<EnemyHitbox>();

        if (controller != null)
        {
            controller.ChangeHealth(-3);
            Destroy(gameObject);
            Debug.Log("It's an attack!");
        }
    }
    public void Blocked(float shieldValue)
    {
        if (damageValue <= 0)
            Destroy(gameObject);
    }

}