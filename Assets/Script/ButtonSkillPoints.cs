using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkillPoints : MonoBehaviour
{
    public Button yourButton;
    public KoboldSkillController KoboldTargetSkills;
    public KoboldController KoboldTarget;
    public UISkills ButtonTextTarget;
    public int CharacterNumber;
    void Start()
    {
        CharacterNumber = KoboldTarget.CharacterNumber;
    }
    public void IncreaseSkill()
    {
        KoboldTargetSkills.SkillPointUse(ButtonTextTarget.SkillType);
        //the commented out text would make it so you can't interact with the button after clicked, but it needs significantly more logic
        //       if (KoboldTargetSkills.SkillPoints < 1)
        //     {
        //       yourButton.interactable = false;
        // }
    }
}
