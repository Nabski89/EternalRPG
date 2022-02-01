using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollideCAVE : MonoBehaviour
{

    public int DepthProgress = 0;
    // I have no idea what thresholds on digging out the cave should be, but there clearly should be some.

    //cave specific above this line
    private int MouseOverTiming;
    public string MouseOverText = "Error";
    public float ResourceProgress = 0;
    public float ResourceProgressReqd = 300;
    public int Degrade = 0;
    public int Uses = 1000000;

    //read in each stat, skill will need to turn into some kind of enum list most likely
    //not public because they are basically ready only
    float sanguineValue;
    float soulValue;
    float strongValue;
    float smartValue;
    float speedValue;
    float skillValue;
    //the mod that goes along with each stat
    public float sanguineMod = 0.05f; //levels range from 1 to 20? so max level would double original speed
    public float soulMod = 0.05f;
    public float strongMod = 0.05f;
    public float smartMod = 0.05f;
    public float speedMod = 0.05f;
    public float skillMod = 0.2f; //common max level is 5, which would double the speed

    public KoboldSkillController.Skill SkillType;

    public int RNGOre;
    public int RNGDDamage;

    // not being used but we might want to access more than one type or resource from a file at a time

    public static ResourceCollideCAVE instance { get; set; }
    void Awake()
    {
        instance = this;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldSkillController controllerSkill = other.GetComponent<KoboldSkillController>();

        if (controller != null)
        {
            Debug.Log("Character has " + controller.Stamina + " stamina");
            Debug.Log("Character has " + controllerSkill.SkillDic[SkillType] + " Skill in " + SkillType);

            //set our modifiers so we don't have to rereference it every time

            //force the character to go to the center of this resource, so you can't do two at once
            Vector2 position = transform.position;
            controller.targetX = position.x;
            controller.targetY = position.y;


            sanguineValue = controller.sanguine;
            soulValue = controller.soul;
            strongValue = controller.strong;
            smartValue = controller.smart;
            speedValue = controller.speed;


            controller.ProgressBar.SetActive(true);
            controller.ProgressIdle = 0;
            //            skillValue = controller.WHATEVER THE ENUM SKILL IS DEFINED AS
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //these really don't need to be called every frame but WHATEVER
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldSkillController controllerSkill = other.GetComponent<KoboldSkillController>();

        if (controller != null && controllerSkill != null)
        {
            //        controller.SKILLTrigger(1); //this might be neat later?

            ResourceProgress =
            ResourceProgress
            + 1
            + sanguineValue * sanguineMod
            + soulValue * soulMod
            + strongValue * strongMod
            + smartValue * smartMod
            + speedValue * speedMod
            + skillValue * skillMod
            ;

            controller.ProgressBarUpdate(ResourceProgress / ResourceProgressReqd);

            if (ResourceProgress > ResourceProgressReqd)
            {
                DigCave();
                ResourceProgress = 0;
                Debug.Log("GAIN 1 RESOURCE");
                GainOre();
                ResourceEnum.ResourceChange();
                Debug.Log("GAIN 1 RESOURCE");

                //level up the skill, probably shouldn't be only on completion but it's kinda hilarious to have two people working and only one levels up randomly.
                controllerSkill.GainSkill();
                Degrade += 1;
                if (Degrade > Uses)
                {
                    Exhaust();
                    Debug.Log("Degraded");
                    Degrade = 0;
                }
            }
        }
    }

    public void OnMouseOver()
    {
        MouseOverTiming += 1;
        if (MouseOverTiming == 15)
        {
            Debug.Log("We Hovered over this thing");
            MouseOverText = "This structure creates Stone, Metal, Gold, and Gems";
 //           MouseOverText = MouseOverText.Remove(MouseOverText.Length - 2, 2);
            MouseOverText += "\n You will improve at " + SkillType;
            MouseOverText += "\n You have only just started to explore it ";
            foreach (var UIMouseOverBox in GameObject.FindObjectsOfType<UIInfoBox>())
            {
                UIMouseOverBox.signaltotheworldthatIhavedonesomething(MouseOverText);
            }
        }
    }

    void OnMouseExit()
    {
        MouseOverTiming = 0;
    }

    void Exhaust()
    {
        var rendererer = GetComponent<Renderer>();
        rendererer.material.SetColor("_Color", Color.red);
        ResourceProgressReqd = ResourceProgressReqd * 5;
    }





    //cave specific things below this line, everything else gets re-copy pasted whenever we update cave-explore.

    void DigCave()
    {
        DepthProgress += 1;
        if (DepthProgress > 10)
        {
            Debug.Log("GAIN 1 RESOURCE");
            DepthProgress = 0;
            ResourceEnum.ResourceChangeMax(ResourceEnum.Resource.StoneC1, 1);
        }
    }



    void GainOre()
    {
        RNGOre = Random.Range(1, 48);
        if (RNGOre > 17)
        {
            OreType(ResourceEnum.Resource.StoneC1);
        }
        if (RNGOre > 7 && RNGOre < 18)
        {
            OreType(ResourceEnum.Resource.GoldC2);
        }
        if (RNGOre > 2 && RNGOre < 8)
        {
            OreType(ResourceEnum.Resource.OreC3);
        }
        if (RNGOre < 3)
        {
            OreType(ResourceEnum.Resource.CrystalC4);
        }
    }

    void OreType(ResourceEnum.Resource ORE)
    {
        ResourceEnum.ResourceDic[ORE] = Mathf.Clamp(ResourceEnum.ResourceDic[ORE] + 1, 0, ResourceEnum.ResourceMaxDic[ORE]);
    }
}