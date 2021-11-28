using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
        public static ButtonController instance { get; set; }
    public int resting = 0;
    public int maxHealth = 10;
    public int currentHealth = 10;

    //Stamina, controls resting
    public int StaminaMax = 600;
    public int StaminaRegen = 4;
    public int Stamina = 600;

    //Mana, controls casting spells
    public int ManaMax = 100;
    public int ManaRegen = 1;
    public int Mana = 1;

    //Age, Controls if you die


    //some skills
    public int skill = 0;
    public int skillUpReq = 10;
    public int skillUpProgress = 0;
    public int ActiveObject = 0;


    //DNA things to pass down, should probably be an array
    public int DNA1X;
    public int DNA1Y;
    public int DNA2X;
    public int DNA2Y;

    public int babymake = 0;
    public int babymakeCooldown = 1200;

    // Start is called before the first frame update
    void awake()
    {
        instance = this;
    }

    void Start()
    {
 maxHealth = 10;
 currentHealth = 10;
 ActiveObject = 0;


             DNA1X = Reproduce.instance.DNA1X;
    }






    public void babymakeing(int babyamount)
    {
        if (babymake == 0)
        {
            Debug.Log("SINGLE AND READY TO MINGLE");
            if (babymakeCooldown == 0)
            {
                Debug.Log("Not on cooldown");
                babymakeCooldown = 1200; babymake = babyamount;
            }
        }
        else { Debug.Log("You've already got a kid in the oven"); }
    }
    public void OnMouseDown()
    {
//Deselect everything
ActiveObject = 0;

//until the next 9 lines are about if you clicked on something             
RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
if(hit.collider != null)
{
    Debug.Log ("Target Position: " + hit.collider.gameObject.transform.position);
    Debug.Log ("You hit this bitch");
    ActiveObject = 1;
}
else{    Debug.Log ("Miss");};
//end clicking on something             

                    //           transform.localScale += new Vector3(1, 0, 1);
    }

    //some random script that should really be it's own file



    public int crafting = 100;
    public void CraftingTrigger(int CraftSpeed)
    {
        crafting = crafting - CraftSpeed;
        if (0 >= crafting)
        {
            crafting = 100;

            CraftResearch controller = GetComponent<CraftResearch>();

            if (controller != null)
            {
                //         controller.due(1);
            }

        }
    }
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
    //use this to update yourself every tick but not get it lost
    public void UpdateSelf()
    {

        babymakeCooldown = Mathf.Max(babymakeCooldown - 1, 0);

        UIMana.instance.SetValue(Mana / (float)ManaMax);
        Mana = Mathf.Clamp(Mana + ManaRegen, 0, ManaMax);
    }



    // Update is called once per frame
    void Update()
    {
        //Multiply everything by time delta I guess because it's updated per frame for some janky reason
        if (resting == 0 && ActiveObject == 1)
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

            if (Stamina >= 600)
            {
                Stamina = StaminaMax;
                resting = 0;
            }
        }
        //update our stamina bar
        UIStam.instance.SetValue(Stamina / (float)StaminaMax);

        UpdateSelf();



        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            ResourceTracker.instance.SetValue(skill);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ResourceTracker.instance.books = 7;
            ResourceTracker.instance.SetValue(skill);

            skill = ResourceTracker.instance.books;
 
         Debug.Log("Skill incoming from the other function is " + skill);
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


