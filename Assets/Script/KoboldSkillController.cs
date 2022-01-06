using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldSkillController : MonoBehaviour
{
    public int ValueToRead = 3;
    public float SkillPoints = 3;

    //for use to update a progress bar when performing an action
    public GameObject ProgressBar;
    public GameObject ProgressMeter;

    // Start is called before the first frame update
    public enum Skill { G1, G2, G3, G4, G5, P1, P2, P3, P4, P5, M1, M2, M3, M4, M5, C1, C2, C3, C4, C5 };

    public Dictionary<Skill, float> SkillDic = new Dictionary<Skill, float>();
    public Dictionary<Skill, string> SkillNameDic = new Dictionary<Skill, string>();
    public Dictionary<Skill, float> SkillExpDic = new Dictionary<Skill, float>();
    public Dictionary<Skill, float> SkillMaxDic = new Dictionary<Skill, float>();

    public KoboldController TargetController;
    void Awake()
    {


        assignDic(Skill.G1, Skill.G2, Skill.G3, Skill.G4, Skill.G5);
        assignDic(Skill.P1, Skill.P2, Skill.P3, Skill.P4, Skill.P5);
        assignDic(Skill.M1, Skill.M2, Skill.M3, Skill.M4, Skill.M5);
        assignDic(Skill.C1, Skill.C2, Skill.C3, Skill.C4, Skill.C5);

        SkillNameDic[Skill.G1] = "Study";
        SkillNameDic[Skill.G2] = "Planning";
        SkillNameDic[Skill.G3] = "Writing";
        SkillNameDic[Skill.G4] = "Leadership";
        SkillNameDic[Skill.G5] = "Inspiration";

        SkillNameDic[Skill.G1] = "Harvesting";
        SkillNameDic[Skill.G2] = "Green Claw";
        SkillNameDic[Skill.G3] = "Brewing";
        SkillNameDic[Skill.G4] = "Alchemy";
        SkillNameDic[Skill.G5] = "Infusion";

        SkillNameDic[Skill.G1] = "Spawk";
        SkillNameDic[Skill.G2] = "Concentration";
        SkillNameDic[Skill.G3] = "Conjuration";
        SkillNameDic[Skill.G4] = "Binding";
        SkillNameDic[Skill.G5] = "Mastery";

        SkillNameDic[Skill.G1] = "Strength";
        SkillNameDic[Skill.G2] = "Crafting";
        SkillNameDic[Skill.G3] = "Prospecting";
        SkillNameDic[Skill.G4] = "Smithing";
        SkillNameDic[Skill.G5] = "Armor Trimming"; //One of the only two named well, game currently needs soul
    }


    void assignDic(Skill S1, Skill S2, Skill S3, Skill S4, Skill S5)
    {
        SkillDic[Skill.G1] = 0;
        SkillDic[Skill.G2] = 0;
        SkillDic[Skill.G3] = 0;
        SkillDic[Skill.G4] = 0;
        SkillDic[Skill.G5] = 0;
    }

        void assignExpDic(Skill S1, Skill S2, Skill S3, Skill S4, Skill S5)
    {
        SkillDic[Skill.G1] = 0;
        SkillDic[Skill.G2] = 0;
        SkillDic[Skill.G3] = 0;
        SkillDic[Skill.G4] = 0;
        SkillDic[Skill.G5] = 0;
    }


    void assignMaxDic(Skill S1, Skill S2, Skill S3, Skill S4, Skill S5)
    {
        SkillDic[Skill.G1] = 0;
        SkillDic[Skill.G2] = 0;
        SkillDic[Skill.G3] = 0;
        SkillDic[Skill.G4] = 0;
        SkillDic[Skill.G5] = 0;
    }


    void Start()
    {

    }

    //update our skill bar, make sure to include some kind of character number in this so we don't update a fuck ton of stuff?
    //THESE NEED TO INCLUDE CHARACTER NUMBERS
    public void SkillUpdate()
    {
        foreach (var SkillType in GameObject.FindObjectsOfType<UISkills>())
        {
            SkillType.SkillUpdate();
        }
    }

    public void SkillPointUpdate()
    {
        foreach (var SkillType in GameObject.FindObjectsOfType<UISkillPoints>())
        {
            SkillType.SkillPointUpdate();
        }
    }

    // Update is called once per frame
    public void GainSkill(Skill Skill)
    {
        Debug.Log("GAINSKILL");

        if (SkillDic[Skill] < SkillMaxDic[Skill])
        {
            SkillExpDic[Skill] += 1;

            //check if we have enough XP to level up, this formula will 100% need to be revisited
            if (SkillExpDic[Skill] > SkillDic[Skill] * 2)
            {
                SkillDic[Skill] += 1;

                Debug.Log("LEVEL UP");

                SkillPoints += 0.1f;
            }

            SkillUpdate();
        }
    }
    public void ResetSkills(int PlayerNumber)
    {
        if (PlayerNumber == TargetController.CharacterNumber)
        {
        assignDic(Skill.G1, Skill.G2, Skill.G3, Skill.G4, Skill.G5);
        assignDic(Skill.P1, Skill.P2, Skill.P3, Skill.P4, Skill.P5);
        assignDic(Skill.M1, Skill.M2, Skill.M3, Skill.M4, Skill.M5);
        assignDic(Skill.C1, Skill.C2, Skill.C3, Skill.C4, Skill.C5);


                    assignExpDic(Skill.G1, Skill.G2, Skill.G3, Skill.G4, Skill.G5);
        assignExpDic(Skill.P1, Skill.P2, Skill.P3, Skill.P4, Skill.P5);
        assignExpDic(Skill.M1, Skill.M2, Skill.M3, Skill.M4, Skill.M5);
        assignExpDic(Skill.C1, Skill.C2, Skill.C3, Skill.C4, Skill.C5);

                    assignDic(Skill.G1, Skill.G2, Skill.G3, Skill.G4, Skill.G5);
        assignMaxDic(Skill.P1, Skill.P2, Skill.P3, Skill.P4, Skill.P5);
        assignMaxDic(Skill.M1, Skill.M2, Skill.M3, Skill.M4, Skill.M5);
        assignMaxDic(Skill.C1, Skill.C2, Skill.C3, Skill.C4, Skill.C5);

            SkillPoints = 3;
        }
    }
    public void RefreshSkills(int refresh1, int refresh2, int refresh3, int refresh4)
    {
        SkillPoints = 3;

        SkillDic[Skill.M1] = refresh1;
        SkillDic[Skill.C1] = refresh2;
        SkillDic[Skill.G1] = refresh3;
        SkillDic[Skill.P1] = refresh4;

        SkillPointUpdate();
        SkillUpdate();
    }


    public void SkillPointUse(Skill Skill)
    {
        //      if(SkillPoints >= 1){
        SkillPoints -= 1;
        SkillMaxDic[Skill] += 5;
        SkillPointUpdate();
        SkillUpdate();
        //    }
    }
}
