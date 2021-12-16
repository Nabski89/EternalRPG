using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //shoot forward
    //base attributes off the attacker and some other stuff
    //call the change health script
public int damageValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        ButtonController controller = other.GetComponent<ButtonController>();

        if (controller != null)
        {
            Debug.Log("It's an attack!");
            //set our modifiers so we don't have to rereference it every time
            //            skillValue = controller.WHATEVER THE ENUM SKILL IS DEFINED AS

            controller.ChangeHealth(damageValue);
        }
    }

    void Update()
    {

    }
}
