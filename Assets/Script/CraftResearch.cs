using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftResearch : MonoBehaviour
{
    public int resource1 = 1;
    public int resource2 = 2;

    public int crafted1 = 1;
    public int crafted2 = 2;

    void OnTriggerEnter2D(Collider2D other)
    {
        /*       ButtonController controller = other.GetComponent<ButtonController>();

               if (controller != null)
               {
                   controller.ChangeHealth(1);
               }
        */
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ButtonController controller = other.GetComponent<ButtonController>();

        if (controller != null)
        {
            controller.CraftingTrigger(1);
        }
    }




    public void Create(int Tier)
    {
    }
}