using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollide : MonoBehaviour
{
    public float ResourceProgress = 0;
    public float ResourceProgressReqd = 300;
    public UIResources target;

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

    public ResourceEnum.T1Resource ResourceType;
    public KoboldSkillController.T1Skill SkillType;

    // not being used but we might want to access more than one type or resource from a file at a time
    //    public string ResourceType2 = "butter"

    public static ResourceCollide instance { get; set; }
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
            Debug.Log("Entered the " + ResourceEnum.T1Dic[ResourceType] + " zone");
            Debug.Log("Character has " + controller.Stamina + " stamina");
            Debug.Log("Character has " + controllerSkill.T1SkillDic[SkillType] + " Skill in " + SkillType); //CRASHES ON THIS LINE

            //set our modifiers so we don't have to rereference it every time

            sanguineValue = controller.sanguine;
            soulValue = controller.soul;
            strongValue = controller.strong;
            smartValue = controller.smart;
            speedValue = controller.speed;
            //            skillValue = controller.WHATEVER THE ENUM SKILL IS DEFINED AS
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        //these really don't need to be called every frame but WHATEVER
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldSkillController controllerSkill = other.GetComponent<KoboldSkillController>();

        if (controller != null)
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

            if (ResourceProgress > ResourceProgressReqd)
            {
                ResourceProgress = 0;
                Debug.Log("GAIN 1 RESOURCE");
                ResourceEnum.T1Dic[ResourceType] = ResourceEnum.T1Dic[ResourceType] + 1;
                ResourceEnum.ResourceChange();
                Debug.Log("GAIN 1 RESOURCE");
                controllerSkill.GainSkill(SkillType);
            }
        }


    }

    void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log("You Clicked the meat");
        Debug.Log("Target Position: " + transform.position.x);
        Debug.Log("Target Position: " + transform.position.y);
    }

    void update()
    {

    }
    //        void TravelTo(transform.position.x, transform.position.y);
}