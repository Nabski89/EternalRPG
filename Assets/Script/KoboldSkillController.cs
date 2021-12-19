using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldSkillController : MonoBehaviour
{
    public int ValueToRead = 3;
    public float SkillPoints = 3;
    // Start is called before the first frame update
    public enum T1Skill { Tending, Mining, Harvesting, Planning };

    public Dictionary<T1Skill, float> T1SkillDic = new Dictionary<T1Skill, float>();
    public Dictionary<T1Skill, float> T1SkillExpDic = new Dictionary<T1Skill, float>();
    public Dictionary<T1Skill, float> T1SkillMaxDic = new Dictionary<T1Skill, float>();

    public KoboldController TargetController;
    void Awake()
    {
        T1SkillDic[T1Skill.Tending] = 0;
        T1SkillDic.Add(T1Skill.Mining, 0);
        T1SkillDic.Add(T1Skill.Harvesting, 0);
        T1SkillDic.Add(T1Skill.Planning, 0);

        T1SkillExpDic[T1Skill.Tending] = 0;
        T1SkillExpDic.Add(T1Skill.Mining, 0);
        T1SkillExpDic.Add(T1Skill.Harvesting, 0);
        T1SkillExpDic.Add(T1Skill.Planning, 0);

        T1SkillMaxDic[T1Skill.Tending] = 5;
        T1SkillMaxDic.Add(T1Skill.Mining, 5);
        T1SkillMaxDic.Add(T1Skill.Harvesting, 5);
        T1SkillMaxDic.Add(T1Skill.Planning, 5);
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
    public void GainSkill(T1Skill Skill)
    {
        Debug.Log("GAINSKILL");

        if (T1SkillDic[Skill] < T1SkillMaxDic[Skill])
        {
            T1SkillExpDic[Skill] += 1;

            //check if we have enough XP to level up, this formula will 100% need to be revisited
            if (T1SkillExpDic[Skill] > T1SkillDic[Skill] * 2)
            {
                T1SkillDic[Skill] += 1;

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
            T1SkillDic[T1Skill.Tending] = 0;
            T1SkillDic[T1Skill.Mining] = 0;
            T1SkillDic[T1Skill.Harvesting] = 0;
            T1SkillDic[T1Skill.Planning] = 0;

            T1SkillExpDic[T1Skill.Tending] = 0;
            T1SkillExpDic[T1Skill.Mining] = 0;
            T1SkillExpDic[T1Skill.Harvesting] = 0;
            T1SkillExpDic[T1Skill.Planning] = 0;

            T1SkillMaxDic[T1Skill.Tending] = 0;
            T1SkillMaxDic[T1Skill.Mining] = 0;
            T1SkillMaxDic[T1Skill.Harvesting] = 0;
            T1SkillMaxDic[T1Skill.Planning] = 0;

            SkillPoints = 3;
        }
    }
    public void RefreshSkills(int refresh1, int refresh2, int refresh3, int refresh4)
    {
        SkillPoints = 3;

        T1SkillDic[T1Skill.Tending] = refresh1;
        T1SkillDic[T1Skill.Mining] = refresh2;
        T1SkillDic[T1Skill.Harvesting] = refresh3;
        T1SkillDic[T1Skill.Planning] = refresh4;

        SkillPointUpdate();
        SkillUpdate();
    }


    public void SkillPointUse(T1Skill Skill)
    {
        //      if(SkillPoints >= 1){
        SkillPoints -= 1;
        T1SkillMaxDic[Skill] += 5;
        SkillPointUpdate();
        SkillUpdate();
        //    }
    }
}
