using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public int resting = 0;


    public int maxHealth = 10;
    public int currentHealth = 10;

    //Stamina, controls resting
    public int StaminaMax = 600;
    public int StaminaRegen = 4;
    public int Stamina = 600;

    //Mana, controls casting spells
    public int ManaMax = 100;
    public int ManaRegen = 0;
    public int Mana = 1;

    //Age, Controls if you die


    //some skills
    public int skill = 0;
    public int skillUpReq = 10;
    public int skillUpProgress = 0;


    //some random script that should really be it's own file


    //Do a //if Mana>Mana Cost first
    public void SpendMana(int ManaCost)
    {
        Mana = Mana - ManaCost;
        /*   if (skillUpProgress >= skillUpReq)
           {
             skill=skill+1;
             skillUpReq = 10 + skill*skill;
             skillUpProgress = 0;
           }  */
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //This sends it to the health UI
        UIHealth.instance.SetValue(currentHealth / (float)maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    //Dis shoots da bullet

public GameObject projectilePrefab;
    void Launch()
    {
        Debug.Log("Ur a wizard arry");

        GameObject projectileObject = Instantiate(projectilePrefab);

  //      projectilePrefab projectile = projectileObject.GetComponent<projectilePrefab>();
 //       projectile.Launch(lookDirection, 300);
  
    }
    


    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Mana = Mathf.Clamp(Mana + ManaRegen, 0, ManaMax);
        UIMana.instance.SetValue(Mana / (float)ManaMax);
        //Multiply everything by time delta I guess because it's updated per frame for some janky reason
        if (resting == 0)
        {

            //these make it move with the arrow keys       
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + 1f * horizontal * Time.deltaTime; ;
            position.y = position.y + 1f * vertical * Time.deltaTime; ;
            transform.position = position;

            //this is some janky sleep system
            Stamina = Stamina - 1;
            if (Stamina <= 0)
            {
                resting = 1;
            }
        }

        //Go to sleep and restore stamina
        if (resting == 1)
        {
            Stamina = Stamina + StaminaRegen;
            Mana = Mana + ManaRegen;
            if (Stamina >= 600)
            {
                Stamina = StaminaMax;
                resting = 0;
            }
        }
        //update our stamina bar
        UIStam.instance.SetValue(Stamina / (float)StaminaMax);


                if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
    }


    //Here's some things that happen to this unit, in other places

    public void SKILLTrigger(int amount)
    {
        skillUpProgress = skillUpProgress + amount;
        if (skillUpProgress >= skillUpReq)
        {
            skill = skill + 1;
            skillUpReq = 10 + skill * skill;
            skillUpProgress = 0;
        }
        if (skill == 10 && skillUpProgress == 0)
        {
            Debug.Log("Ur a wizard arry");
            //       GameObject ButtonController2 = Instantiate(Object);
        }
    }






    //this is the last line
}


