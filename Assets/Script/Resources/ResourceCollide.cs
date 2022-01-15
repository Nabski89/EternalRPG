using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollide : MonoBehaviour
{
    private int MouseOverTiming;
    public string MouseOverText = "Error";
    public float ResourceProgress = 0;
    public float ResourceProgressReqd = 300;
    public int Degrade = 0;
    public int Uses = 10;

    //read in each stat, skill will need to turn into some kind of enum list most likely
    //not public because they are basically ready only
    float sanguineValue;
    float soulValue;
    float skillValue;
    //the mod that goes along with each stat
    public float sanguineMod = 0.05f; //levels range from 1 to 20? so max level would double original speed
    public float soulMod = 0.05f;
    public float skillMod = 0.2f; //common max level is 5, which would double the speed

    public ResourceEnum.Resource ResourceType;
    public KoboldSkillController.Skill SkillType;

    //set this to the same thing if we aren't using it
    public ResourceEnum.Resource ResourceType2;
    public KoboldSkillController.Skill SkillType2;

    string SkillName;
    public bool IsThisTheKnowledgeBuilding = false;


    // not being used but we might want to access more than one type or resource from a file at a time
    //    public string ResourceType2 = "butter"

    public static ResourceCollide instance { get; set; }
    void Start()
    {
        foreach (var koboldSkill in GameObject.FindObjectsOfType<KoboldSkillController>())
        {
            SkillName = koboldSkill.SkillNameDic[SkillType];
        }

        instance = this;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldSkillController controllerSkill = other.GetComponent<KoboldSkillController>();

        if (controller != null)
        {
            Debug.Log("Entered the " + ResourceEnum.ResourceDic[ResourceType] + " zone");
            Debug.Log("Character has " + controllerSkill.SkillDic[SkillType] + " Skill in " + SkillType);

            //set our modifiers so we don't have to rereference it every time

            //force the character to go to the center of this resource, so you can't do two at once
            Vector2 position = transform.position;
            controller.targetX = position.x;
            controller.targetY = position.y;

            sanguineValue = controller.sanguine;
            soulValue = controller.soul;

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
            ;

            controller.ProgressBarUpdate(ResourceProgress / ResourceProgressReqd);

            if (ResourceProgress > ResourceProgressReqd)
            {
                ResourceProgress = 0;
                Debug.Log("GAIN 1 RESOURCE");

                //check if we are able to use the advanced version
                if (controllerSkill.SkillMaxDic[SkillType2] > 1)
                {
                    //knowledge gain is weird and based on our stored type 2, 3, 4 resources
                    if (IsThisTheKnowledgeBuilding == true)
                    {
                        //call these out
                        int G2Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.PictureG2];
                        int G3Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.ScrollG3];
                        int G4Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.BookG4];
                        //then gain it, t2 gets 1, t3 2, t4 3 
                        ResourceEnum.ResourceDic[ResourceType2] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceType2] + 1 * G2Multiplier + 2 * G3Multiplier + 3 * G4Multiplier, 0, ResourceEnum.ResourceMaxDic[ResourceType2]);
                    }
                    else
                    {
                        ResourceEnum.ResourceDic[ResourceType2] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceType2] + 1, 0, ResourceEnum.ResourceMaxDic[ResourceType2]);
                    }
                    controllerSkill.GainSkill(SkillType2);
                }
                else
                {
                    //knowledge gain is weird and based on our stored type 2, 3, 4 resources
                    if (IsThisTheKnowledgeBuilding == true)
                    {
                        //call these out
                        int G2Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.PictureG2];
                        int G3Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.ScrollG3];
                        int G4Multiplier = ResourceEnum.ResourceDic[ResourceEnum.Resource.BookG4];
                        //then gain it, t2 gets 1, t3 2, t4 3 
                        ResourceEnum.ResourceDic[ResourceType] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceType] + 1 * G2Multiplier + 2 * G3Multiplier + 3 * G4Multiplier, 0, ResourceEnum.ResourceMaxDic[ResourceType]);
                    }
                    else
                    {
                        ResourceEnum.ResourceDic[ResourceType] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceType] + 1, 0, ResourceEnum.ResourceMaxDic[ResourceType]);
                    }
                    controllerSkill.GainSkill(SkillType);
                }

                //resource change updates our resource trackers
                ResourceEnum.ResourceChange();
                Debug.Log("GAIN RESOURCE");

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


    void GetResource(ResourceEnum.Resource GetResource)
    {



    }



    public void OnMouseOver()
    {
        MouseOverTiming += 1;
        if (MouseOverTiming == 15)
        {
            Debug.Log("We Hovered over this thing");
            MouseOverText = "This structure creates " + ResourceType;
            MouseOverText = MouseOverText.Remove(MouseOverText.Length - 2, 2);
            if (ResourceType != ResourceType2)
            {
                MouseOverText += "and" + ResourceType2;
                MouseOverText = MouseOverText.Remove(MouseOverText.Length - 2, 2);
            }

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
}