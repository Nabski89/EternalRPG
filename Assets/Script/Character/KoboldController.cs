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

    //for updating progress based skills
    public GameObject ProgressBar;
    public GameObject ProgressMeter;
    private float ProgressPercent = 0;
    private float ProgressPreviousPercent = 0;
    public int ProgressIdle = 0;

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
    public int Stamina = 18000;
    public float maxHealth = 100;
    public float currentHealth = 100;
    //soul stats Mana, controls casting spells
    public float Mana = 1;
    public float ManaMax = 20;
    //strong stats
    //smart stats
    public float ManaRegen = 1 / 30;
    //speed stats
    // Is this the moving object
    public int CharacterNumber = 1;

    public float targetX = 5;
    public float targetY = 5;
    public int NeedsToMove = 1;

    public int foodCounter = 1800;
    public int hungry = 0;

    //used for the mouse click commander
    public Vector3 worldPosition;

    // Start is called before the first frame update
    void awake()
    {
        //We need to know what our progress bar is up to
        Vector2 ProgressMeterScale = ProgressMeter.transform.position;
        Vector2 ProgressMeterPosition = ProgressMeter.transform.position;
    }

    void Start()
    {

    }


    //This currently is not in use
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
    public void SpendMana(float ManaCost)
    {
        Mana = Mana - ManaCost;
        /*   if (skillUpProgress >= skillUpReq)
           {
             skill=skill+1;
             skillUpReq = 10 + skill*skill;
             skillUpProgress = 0;
           }  */
    }
    public void ChangeHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //This sends it to the health UI
        HEALTHBAR.SetValue(currentHealth / (float)maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        if (currentHealth < 1)
        {
            Stamina = Stamina - 1800;
            Vector2 position = transform.position;
            if (position.y > 18)
            {
                position.x = position.x - 5;
                position.y = 25 + 1;
            }
            //should probably figure out a better location to place it
            transform.position = position;
        }
    }
    void eat()
    {
        if (ResourceEnum.ResourceDic[ResourceEnum.Resource.MeatP1] > 0)
        {
            ResourceEnum.ResourceDic[ResourceEnum.Resource.MeatP1] = ResourceEnum.ResourceDic[ResourceEnum.Resource.MeatP1] - 1;
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
        //this was some janky sleep system, that turned into a hunger system
        Stamina = Stamina - (1 + hungry);
        if (Stamina <= 0)
        {
            Debug.Log("You got old and died");
            Dead = true;

            foreach (var resource in GameObject.FindObjectsOfType<KoboldSkillController>())
            {
                resource.ResetSkills(CharacterNumber);
            }
            TeleportToCoordinate(-100, -100);
        }
    }

    void ProgressBarUpdate()
    {
        if (ProgressPreviousPercent == ProgressPercent)
        {
            ProgressIdle += 1;
            if (ProgressIdle >= 45)
            {
                ProgressBar.SetActive(false);
            }
        }
    }

    public void ProgressBarUpdate(float PERCENT)
    {
        //update the little meter below the character
        ProgressMeter.transform.localScale = new Vector3(PERCENT * 1.6f, 1, 1);
        ProgressMeter.transform.position = ProgressBar.transform.position + new Vector3(PERCENT - 1, 0, 0);
        //keep it from going away
        ProgressIdle = 0;
    }
    public void UpdateSelf()
    {

        hunger();
        stamina();
        ProgressBarUpdate();

        //update our stamina bar
        STAMINABAR.SetValue(Stamina / (float)StaminaMax);

        //and regen mana
        if (Mana < ManaMax)
        {
            Mana = Mathf.Clamp(Mana + ManaRegen, 0, ManaMax);
        }
        if (Mana < 0)
        {
            Mana = Mana + ManaRegen;
            ChangeHealth(-2 / 30);
        }
        if (Mana > ManaMax)
        {
            Mana = Mathf.Clamp(Mana - ManaRegen, ManaMax, 999);
        }


        //mana bar
        MANABAR.SetValue(Mana / (float)ManaMax);

    }


    public float MouseDistance = 50f;
    // Update is called once per frame


public bool Selected = false;
    void OnMouseDown()
    {
        foreach (var koboldC in GameObject.FindObjectsOfType<KoboldController>())
        {
            koboldC.Selected = false;
        }
        Selected = true;
    }
    void Update()
    {
        if (Selected == true)
        {


            if (Input.GetMouseButtonDown(0))
            {
                //check to make sure we didn't click on the UI

                Vector3 mousePos = Input.mousePosition;
                if (mousePos.x > 230 && mousePos.y > 220)
                {
                    //the coordinates for the actual world
                    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 worldPoint2d = new Vector2(worldPoint.x, worldPoint.y);
                    targetX = Mathf.Clamp(0, worldPoint2d.x, CameraScript.WorldSizeX);
                    targetY = Mathf.Clamp(0, worldPoint2d.y, CameraScript.WorldSizeY);
                    NeedsToMove = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Drop Armor");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Drop Tool");
            }
        }

        if (NeedsToMove == 1)
        {
            // this code moves us
            // the math bit decides if it goes right or left

            //this means it moves at about 1 unit per second, our screen is about 30 units wide.
            Vector2 position = transform.position;
            position.x = position.x + 1f * Time.deltaTime * Mathf.Clamp(targetX - position.x, -1, 1);
            position.y = position.y + 1f * Time.deltaTime * Mathf.Clamp(targetY - position.y, -1, 1);
            transform.position = position;

            //Are we there yet?
            if (Mathf.Abs(targetY - position.y) < .05 && Mathf.Abs(targetX - position.x) < 0.5)
            {
                NeedsToMove = 0;
            }
            //Multiply everything by time delta I guess because it's updated per frame for some janky reason
        }

        UpdateSelf();

        //starting from here you can push buttons to activate abilities
        /*
                if (Input.GetKeyDown(KeyCode.C))
                {
                    Launch();
                }
                if (Input.GetKeyDown(KeyCode.V))
                {

                }
                      if (Input.GetKeyDown(KeyCode.X))
                }  */
    }


    //Here's some things that happen to this unit, in other places
    public void TeleportToArea(int Area, int CombatArea)
    {
        Debug.Log("BUTTON TELEPORT ACTIVATE");
        Vector2 position = transform.position;
        position.x = (CombatArea * 50) + 10 + CharacterNumber;
        if (CombatArea == 1)
        {
            position.y = 30;
        }
        else
        {
            position.y = 0;
        }
        transform.position = position;
    }
    public void TeleportToCoordinate(float X, float Y)
    {
        Debug.Log("BUTTON TELEPORT ACTIVATE");
        Vector2 position = transform.position;
        position.x = X;
        position.y = Y;
        transform.position = position;
    }

    public void rebirth(float x, float y)
    {
        DNATarget.rebirthDNA();
        Body1Target.RefreshBody();
        maxHealth = 100;
        currentHealth = 100;
        Stamina = StaminaMax;
        foodCounter = 1800;
        hungry = 0;
        Dead = false;
        TeleportToCoordinate(x, y);
        /* these are waiting until I make the rest of the body
        Body2Target.RefreshBody();
        Body3Target.RefreshBody();
        Body4Target.RefreshBody();
        Body5Target.RefreshBody();
        Body6Target.RefreshBody();
        */
        //skill refresh is handled in the DNA rebirth section
    }



    //POTIONS!
    public int PotionMax = 6;
    public int PotionCount;

    public int HealthPot = 0;
    public int ManaPot = 0;

    public void PotionUIUpdate()
    {

        PotionCount = HealthPot + ManaPot;


        foreach (var resource in GameObject.FindObjectsOfType<UIPotion>())
        {
            resource.UpdateUI(CharacterNumber, HealthPot, ManaPot);
        }
    }
    public void UsePotionHP()
    {
        if (HealthPot > 0)
        {
            HealthPot -= 1;
            ChangeHealth(40);
            PotionUIUpdate();
        }
    }

    public void UsePotionMana()
    {
        if (ManaPot > 0)
        {
            ManaPot -= 1;
            Mana += 10;
            PotionUIUpdate();
        }
    }

}