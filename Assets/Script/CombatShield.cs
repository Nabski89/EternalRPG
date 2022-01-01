using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatShield : MonoBehaviour
{
    public float blockValue = 5f;
    public float decayValue = .1f;
    public float direction = -1f;
    // Start is called before the first frame update
    void Awake()
    {

        Debug.Log("It's an shield!");
        //need to pull info from parent
        Destroy(gameObject, 60);

        Vector2 position = transform.position;
        position.x = position.x + 5f * direction;
        transform.position = position;
    }

/*    public void SetValues(float Attack, string TYPE1, float Attack2, string TYPE2, float FIRE)
    {
        if (TYPE1 == "DAMAGE")
        {
            //           damageValue = Attack;
        }
        if (TYPE2 == "DAMAGE")
        {
            //         damageValue = damageValue + Attack2;
        }
        direction = FIRE;
    }
*/
    public void OnTriggerEnter2D(Collider2D other)
    {
        CombatProjectile controller = other.GetComponent<CombatProjectile>();

        if (controller != null)
        {
            controller.Blocked(blockValue);
            //            blockValue = blockValue - controller.damageValue;
            if (blockValue <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("It's an attack!");
        }
    }

    void Update()
    {
        blockValue = blockValue - decayValue / 30;
        if (blockValue <= 0)
        {
            Destroy(gameObject);
        }
    }
}
