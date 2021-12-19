using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldController : MonoBehaviour
{
    public KoboldDNA DNATarget;
    public KoboldBodyController Body1Target;
    /* for once we have all the variable body parts
    public KoboldBodyController Body2Target;
    public KoboldBodyController Body3Target;
    public KoboldBodyController Body4Target;
    public KoboldBodyController Body5Target;
    public KoboldBodyController Body6Target;
*/
    public KoboldSkillController SkillTarget;
    public UIHealth HEALTHBAR;
    public UIMana MANABAR;
    public UIStam STAMINABAR;

    public bool Dead = false;

    //core stats, to be redefined by DNA
    //the max is what we can gain up to
    public int sanguine;
    public int soul;
    public int strong;
    public int smart;
    public int speed;

    public int sanguineMax;
    public int soulMax;
    public int strongMax;
    public int smartMax;
    public int speedMax;

    //sanguine stats 
    //Age, Controls if you die, needs to be unnamed from stamina

    //Stamina, controls how long someone lives
    public int StaminaMax = 18000;
    public int StaminaRegen = 4;
    public int Stamina = 18000;
    public int maxHealth = 10;
    public int currentHealth = 10;
    //soul stats Mana, controls casting spells
    public float Mana = 1;
    public float ManaMax = 100;
    //strong stats
    public float PunchRegen = 1;
    //smart stats
    public float ManaRegen = 1;
    //speed stats
    public int moveMod;
    public int atkCD;


    //some skills
    public int skill = 0;
    public int skillUpReq = 10;
    public int skillUpProgress = 0;
    // Is this the moving object
    public int CharacterNumber = 1;

    //this controls if it inherits stats from the reproduce script and when it is able to make a new version
    public int babymakeCooldown = 60;

    // Start is called before the first frame update
    void awake()
    {
    }

    void Start()
    {
        maxHealth = 10;
        currentHealth = 10;
    }

    /*   public void OnMouseDown()
       {
           //Deselect everything
           ActiveObject = 0;

           //until the next 9 lines are about if you clicked on something             
           RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
           if (hit.collider != null)
           {
               //         Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
               Debug.Log("Character Active");
               ActiveObject = 1;
           }
           else { Debug.Log("Miss"); };
           //end clicking on something             
           //           transform.localScale += new Vector3(1, 0, 1);
       }
    previous version of my click activation script */
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
        HEALTHBAR.SetValue(currentHealth / (float)maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        if (currentHealth < 1)
        {
            Stamina = Stamina - 1800;
        }
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

    public int foodCounter = 1800;
    public int hungry = 0;
    void eat()
    {
        if (ResourceEnum.T1Dic[ResourceEnum.T1Resource.Meat] > 0)
        {
            ResourceEnum.T1Dic[ResourceEnum.T1Resource.Meat] = ResourceEnum.T1Dic[ResourceEnum.T1Resource.Meat] - 1;
            hungry = hungry - 1;
            ResourceEnum.ResourceChange();
            //maybe we should get something on the foodCounter as a bonus
        }
    }
    void hunger()
    {
        foodCounter = foodCounter - 1;
        if (foodCounter < 1)
        {
            hungry = hungry + 1;
            foodCounter = 1800;
        }
        if (hungry > 0)
        {
            eat();
        }
    }
    void stamina()
    {
        //this is some janky sleep system
        Stamina = Stamina - (1 + hungry);
        if (Stamina <= 0)
        {
            Debug.Log("You got old and died");
            Dead = true;

            foreach (var resource in GameObject.FindObjectsOfType<KoboldSkillController>())
            {
                resource.ResetSkills(CharacterNumber);
            }
        }
    }
    public void UpdateSelf()
    {

        babymakeCooldown = Mathf.Max(babymakeCooldown - 1, 0);

        hunger();
        stamina();

        //update our stamina bar
        STAMINABAR.SetValue(Stamina / (float)StaminaMax);

        //and regen mana
        Mana = Mathf.Clamp(Mana + ManaRegen, 0, ManaMax);

        //mana bar
        MANABAR.SetValue(Mana / (float)ManaMax);

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            /*       RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                   if (hit.collider != null)
                   {
                    //   Debug.Log("Target Position: " + hit.collider.gameObject.transform.position);
                       Debug.Log("Character Active");
                       ActiveObject = 1;
                   }
                   else
                   {
                       Debug.Log("Miss");
                       ActiveObject = 0;
                   };
                   */
        }


        //Multiply everything by time delta I guess because it's updated per frame for some janky reason
        if (CharacterNumber == ActiveCharacterController.CurrentCharacter)
        {

            // this code allows you to move with the arrow keys

            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector2 position = transform.position;
            position.x = position.x + 1f * horizontal * Time.deltaTime; ;
            position.y = position.y + 1f * vertical * Time.deltaTime; ;
            transform.position = position;
        }

        //Go to sleep and restore stamina



        UpdateSelf();

        //starting from here you can push buttons to activate abilities

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            //          ResourceTracker.instance.ResourceGain(skill, books);
        }
        /*      if (Input.GetKeyDown(KeyCode.X))
              {
                  ResourceTracker.instance.books = 7;
                  ResourceTracker.instance.SetValue(skill, books);

                  skill = ResourceTracker.instance.books;

               Debug.Log("Skill incoming from the other function is " + skill);
            }  */
    }


    //Here's some things that happen to this unit, in other places
    public void TeleportToArea(int Area, int CombatArea)
    {
        Debug.Log("BUTTON TELEPORT ACTIVATE");
        Vector2 position = transform.position;
        position.x = (CombatArea * 40) - 3;
        if (CombatArea == 1)
        {
            position.y = 25;
        }
        else
        {
            position.y = 0;
        }
        transform.position = position;

    }
    public void rebirth()
    {
        DNATarget.rebirthDNA();
        Body1Target.RefreshBody();
        /* these are waiting until I make the rest of the body
        Body2Target.RefreshBody();
        Body3Target.RefreshBody();
        Body4Target.RefreshBody();
        Body5Target.RefreshBody();
        Body6Target.RefreshBody();
        */
        //skill refresh is handled in the DNA rebirth section
    }
    //this is the last line
}