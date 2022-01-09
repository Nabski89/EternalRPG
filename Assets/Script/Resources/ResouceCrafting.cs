using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceCrafting : MonoBehaviour
{
int CraftProgress = 0;
int CraftProgressReqd = 300; //we may want to do something to set this based on the value of the equipment, that would be cool

    public ResourceEnum.Resource ResourceType;
    public KoboldSkillController.Skill SkillType;

        string SkillName = "ERROR";


    public static ResouceCrafting instance { get; set; }
    void Start()
    {
        //
        instance = this;
    }

    //when kobold enters, check it's equipment to decide what we are going to craft, maybe include a lock out type trigger titled "CraftingInProgress" so that we can't cheat it
    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldSkillController controllerSkill = other.GetComponent<KoboldSkillController>();
        // need to include the one should be the equipment controller

        if (controller != null)
        {
            Debug.Log("Entered the " + ResourceEnum.ResourceDic[ResourceType] + " zone");
            Debug.Log("Character has " + controllerSkill.SkillDic[SkillType] + " Skill in " + SkillType);

            //set our modifiers so we don't have to rereference it every time

            //force the character to go to the center of this resource, so you can't do two at once
            Vector2 position = transform.position;
            controller.targetX = position.x;
            controller.targetY = position.y;

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
        // again include the bloody equipment one to make sure we craft the right thing

        if (controller != null && controllerSkill != null)
        {
            //        controller.SKILLTrigger(1); //this might be neat later?

            CraftProgress =
            CraftProgress
            + 1;

            controller.ProgressBarUpdate(CraftProgress / CraftProgressReqd);

            if (CraftProgress > CraftProgressReqd)
            {
                CraftProgress = 0;
                Debug.Log("GAIN 1 RESOURCE");

                //either instantiate the thing we need
                //ORRRRR
                //create the equipment

                //then give them the skill update they earned

                //resource change updates our resource trackers
                controllerSkill.GainSkill(SkillType);
            }
        }
    }


    //mouse over text
    private int MouseOverTiming;
    public string MouseOverText = "Error";
    public void OnMouseOver()
    {
        MouseOverTiming += 1;
        if (MouseOverTiming == 15)
        {
            Debug.Log("We Hovered over this thing");
            MouseOverText = "This structure creates " + ResourceType;
            MouseOverText = MouseOverText.Remove(MouseOverText.Length - 2, 2);
            MouseOverText += "\n You will improve at " + SkillName;
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
}
