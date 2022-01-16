using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatProjectile : MonoBehaviour
{
    //shoot forward
    //base attributes off the attacker and some other stuff
    //call the change health script
    public float damageValue = 2;
    public float debuffValue = .2f/30f;
    public float direction = -1f;
    // Start is called before the first frame update
    void Awake()
    {

        Destroy(gameObject, 5);

        Vector2 position = transform.position;
        position.x = position.x + 5f * direction;
        transform.position = position;
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
        KoboldController controller = other.GetComponent<KoboldController>();

        if (controller != null)
        {
            controller.ChangeHealth(-3);
            Destroy(gameObject);
            Debug.Log("It's an attack!");
        }
    }
public void Blocked(float shieldValue)
{
    if(damageValue <= 0)
    Destroy(gameObject);
}
    void Update()
    {
        Vector2 position = transform.position;
        position.x = position.x + 1f * direction;
        position.y = position.y;
        transform.position = position;
    }
}
