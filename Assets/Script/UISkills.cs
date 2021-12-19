using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Make sure you use this or UI stuff won't be there

public class UISkills : MonoBehaviour

{

    public Text UIText;
    public Text UITextSkillPoint;
    public KoboldSkillController Character;
    public KoboldSkillController.T1Skill SkillType;
    public static float SkillValue = 2;
    public static float SkillValueMax = 3;
    // Start is called before the first frame update

    //we want to have an xp bar, and a text for level
    void Start()
    {
        SkillValue = Character.T1SkillDic[SkillType];
        SkillValueMax = Character.T1SkillMaxDic[SkillType];
        //"\n" makes a new text line
        UIText.text = SkillType.ToString() + "\n" + SkillValue.ToString() + " / " + SkillValueMax.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SkillUpdate()
    {
        SkillValue = Character.T1SkillDic[SkillType];
        SkillValueMax = Character.T1SkillMaxDic[SkillType];
        UIText.text = SkillType.ToString() + "\n" + SkillValue.ToString() + " / " + SkillValueMax.ToString();
    }
}
