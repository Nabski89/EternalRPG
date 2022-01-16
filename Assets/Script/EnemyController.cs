using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rb;
    public EnemyCombatController CombatScript;
    public bool NeedsToMove = false;
    public bool CombatMode = false;
    float targetX;
    float targetY;

    int MoveCountDown = 30;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 position = transform.position;
        targetX = position.x;
        targetY = position.y;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();

        if (controller != null)
        {
            Debug.Log("Collision with line");
            //this makes it only move towards PLAYERS not other enemies

            //           Vector3 linePos = controller.transform.position;
            //            float linePosX = controller.transform.position.x;
            //          float linePosY = controller.transform.position.y;
            targetX = controller.transform.position.x;
            targetY = controller.transform.position.y;

            Debug.Log("Go to " + targetX + ", " + targetY + " to fight");

            CombatMode = true;

        float velocitymath = 1 / (Mathf.Sqrt((targetX * targetX) + (targetY * targetY)));
        Debug.Log(velocitymath);
        }


        CombatScript.FIRE(1, 1);
    }

    // Update is called once per frame
    void Update()
    {

        if (CombatMode == true)
        {
            // this code moves us
            // the math bit decides if it goes right or left

            Vector2 position = transform.position;
            position.x = position.x + 1f * Time.deltaTime * Mathf.Clamp(targetX - position.x, -1, 1);
            position.y = position.y + 1f * Time.deltaTime * Mathf.Clamp(targetY - position.y, -1, 1);
            transform.position = position;

            //Are we there yet?
            if (Mathf.Abs(targetY - position.y) < .05 && Mathf.Abs(targetX - position.x) < 0.5)
            {
                NeedsToMove = false;
            }
            //Multiply everything by time delta I guess because it's updated per frame for some janky reason
        }
        else
        {
            IdleMove();
        }
    }

    void IdleMove()
    {
        MoveCountDown -= 1;
        if (MoveCountDown == 0)
        {
            MoveCountDown = Random.Range(0, 6 * 30);
            rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
        }
    }
}
