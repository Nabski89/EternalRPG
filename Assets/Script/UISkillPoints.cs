using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Make sure you use this or UI stuff won't be there

public class UISkillPoints : MonoBehaviour

{
//this probably needs the "use button activate level up" behavior in it
    public KoboldSkillController Character;
    public static float SkillPoints = 3;
    // Start is called before the first frame update

    //we want to have an xp bar, and a text for level
    void Start()
    {
        SkillPoints = Character.SkillPoints;
       gameObject.GetComponent<Text>().text = "Skill Points: " + SkillPoints.ToString();
    }
    public void SkillPointUpdate()
    {
        SkillPoints = Character.SkillPoints;
        gameObject.GetComponent<Text>().text = "Skill Points: " + SkillPoints.ToString();
    }
}
