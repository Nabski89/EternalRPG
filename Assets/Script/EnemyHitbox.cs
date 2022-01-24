using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{

    public void ChangeHealth(float HPChange)
    {
         EnemyController MainBody = gameObject.GetComponentInParent(typeof(EnemyController)) as EnemyController;

         MainBody.ChangeHealth(HPChange);
    }
}
