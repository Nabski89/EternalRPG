using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilePrefab : MonoBehaviour
{
    //makes it a viable rigid 2d body
        //Wait why did I do this?
    Rigidbody2D rigidbody2d;

    int damage = 1;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();


    }


    //shoot in a direction, pew pew
    public void Launch(Vector2 direction, float force, int AttackValue)
    {
        rigidbody2d.AddForce(direction * force);
        AttackValue = damage;
    }



    /*/this is used for when it hits something, default script just makes it delete self
    void OnCollisionEnter2D(Collision2D other)
    {
        //we also add a debug log to know what the projectile touch
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
    */

}