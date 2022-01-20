using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPotion : MonoBehaviour
{
    //THERE ARE A BUNCH OF OPTIONS FOR HOW TO MAKE THIS WORK AND I DON"T KNOW WHICH ONE TO GO WITH
    //SO FOR NOW WE ARE JUST GOING TO BOOLEAN THE POTION TYPE AND DO A MASSIVE IF CHAIN ON PICK UP
    public bool healthpot = false;
    public bool manapot = false;


    // Start is called before the first frame update
    void Start()
    {

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();

        if (controller != null)
        {
            if (controller.PotionMax > controller.PotionCount)
            {

                if (healthpot == true)
                {
                    Debug.Log("Character" + controller.CharacterNumber + "got a health potion");
                    controller.HealthPot += 1;
                    controller.PotionUIUpdate();
                    Destroy(gameObject);
                }

                if (manapot == true)
                {
                    Debug.Log("Character" + controller.CharacterNumber + "got a mana potion");
                    controller.ManaPot += 1;
                    controller.PotionUIUpdate();
                    Destroy(gameObject);
                }
            }
        }
    }

}