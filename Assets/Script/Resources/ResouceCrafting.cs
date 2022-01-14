using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResouceCrafting : MonoBehaviour
{
    public int CraftProgress = 0;
    public int CraftProgressReqd = 300; //we may want to do something to set this based on the value of the equipment, that would be cool

    public KoboldEquipment.Tools ToolType;

    public ResourceEnum.Resource ResourceMake1;
    public ResourceEnum.Resource ResourceCost1;
    public KoboldSkillController.Skill SkillType1;
    public ResourceEnum.Resource ResourceMake2;
    public ResourceEnum.Resource ResourceCost2;
    public KoboldSkillController.Skill SkillType2;
    public ResourceEnum.Resource ResourceMake3;
    public ResourceEnum.Resource ResourceCost3;


    public KoboldSkillController.Skill SkillType3;
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
        KoboldEquipment EquipmentController = other.GetComponent<KoboldEquipment>();
        // need to include the one should be the equipment controller

        if (controller != null)
        {
            Debug.Log(" It's time to try to craft");
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
        KoboldEquipment EquipmentController = other.GetComponent<KoboldEquipment>();
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
                Debug.Log("You got no tool");
                CraftProgress = 0;
                if (Mathf.Floor(EquipmentController.ToolDic[ToolType]) == 0)
                {
                    //if we have no tool we won't craft it but we can train a skill?
                    Debug.Log("You got no tool");
                }
                if (Mathf.Floor(EquipmentController.ToolDic[ToolType]) == 1
                    && ResourceEnum.ResourceDic[ResourceCost1] >= 4
                    && controller.Mana > (20 + (EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10)
                    )

                {

                    ResourceEnum.ResourceDic[ResourceMake1] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake1] - 4, 0, ResourceEnum.ResourceMaxDic[ResourceMake1]);
                    controller.SpendMana(20 + ((EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10));
                    ResourceEnum.ResourceDic[ResourceMake1] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake1] + 1, 0, ResourceEnum.ResourceMaxDic[ResourceMake1]);
                    controllerSkill.GainSkill(SkillType1);
                    Debug.Log("We Made Something");
                }
                if (Mathf.Floor(EquipmentController.ToolDic[ToolType]) == 1
                    && ResourceEnum.ResourceDic[ResourceCost2] >= 3
                    && controller.Mana > (30 + ((EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10))
                    )
                {
                    ResourceEnum.ResourceDic[ResourceMake2] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake2] - 3, 0, ResourceEnum.ResourceMaxDic[ResourceMake2]);
                    controller.SpendMana(30 + ((EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10));
                    ResourceEnum.ResourceDic[ResourceMake2] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake2] + 1, 0, ResourceEnum.ResourceMaxDic[ResourceMake2]);
                    controllerSkill.GainSkill(SkillType2);
                    CraftProgress = 0;
                }
                if (Mathf.Floor(EquipmentController.ToolDic[ToolType]) == 1
                    && ResourceEnum.ResourceDic[ResourceCost3] >= 2
                    && controller.Mana > (50 + ((EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10))
                    )
                {
                    ResourceEnum.ResourceDic[ResourceMake3] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake3] - 2, 0, ResourceEnum.ResourceMaxDic[ResourceMake3]);
                    controller.SpendMana(50 + ((EquipmentController.ToolDic[ToolType]) - Mathf.Floor(EquipmentController.ToolDic[ToolType]) * 10));
                    ResourceEnum.ResourceDic[ResourceMake3] = Mathf.Clamp(ResourceEnum.ResourceDic[ResourceMake3] + 1, 0, ResourceEnum.ResourceMaxDic[ResourceMake3]);
                    controllerSkill.GainSkill(SkillType3);
                    CraftProgress = 0;
                }
                //either instantiate the thing we need
                //ORRRRR
                //create the equipment

                //then give them the skill update they earned

                //resource change updates our resource trackers
                ResourceEnum.ResourceChange();

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
            MouseOverText = "This structure creates " + ResourceMake1;
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
