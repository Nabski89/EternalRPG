using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Make sure you use this or UI stuff won't be there

public class UISkills : MonoBehaviour

{
    public Text UITextSkillPoint;
    public KoboldSkillController Character;
    public KoboldSkillController.Skill SkillType;
    public static float SkillValue = 2;
    public static float SkillValueMax = 3;
    // Start is called before the first frame update

    //we want to have an xp bar, and a text for level
    void Start()
    {
        SkillValue = Character.SkillDic[SkillType];
        SkillValueMax = Character.SkillMaxDic[SkillType];
        //"\n" makes a new text line
        gameObject.GetComponent<Text>().text = Character.SkillNameDic[SkillType] + "\n" + SkillValue.ToString() + " / " + SkillValueMax.ToString();
    }

    // Update is called once per frame
    //    void Update()    {    }
    public void SkillUpdate()
    {
        SkillValue = Character.SkillDic[SkillType];
        SkillValueMax = Character.SkillMaxDic[SkillType];
        gameObject.GetComponent<Text>().text = Character.SkillNameDic[SkillType] + "\n" + SkillValue.ToString() + " / " + SkillValueMax.ToString();
    }
}
