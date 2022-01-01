using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoboldDNA : MonoBehaviour
{
    public KoboldController TargetKobold;
    public KoboldSkillController TargetSkill;


    public enum DNA { Block1, Block2, Block3, Block4, Block5, Block6 };

    public Dictionary<DNA, int> DNADicX = new Dictionary<DNA, int>();
    public Dictionary<DNA, int> DNADicY = new Dictionary<DNA, int>();
    // Start is called before the first frame update
    public bool ValidParent = true;
    void Awake()
    {
        DNADicX[DNA.Block1] = Random.Range(0, 2);
        DNADicX[DNA.Block2] = Random.Range(0, 2);
        DNADicX[DNA.Block3] = Random.Range(0, 2);
        DNADicX[DNA.Block4] = Random.Range(0, 2);
        DNADicX[DNA.Block5] = Random.Range(0, 2);
        DNADicX[DNA.Block6] = Random.Range(0, 2);

        DNADicY[DNA.Block1] = Random.Range(0, 2);
        DNADicY[DNA.Block2] = Random.Range(0, 2);
        DNADicY[DNA.Block3] = Random.Range(0, 2);
        DNADicY[DNA.Block4] = Random.Range(0, 2);
        DNADicY[DNA.Block5] = Random.Range(0, 2);
        DNADicY[DNA.Block6] = Random.Range(0, 2);
    }
    int RandomNUMBER;
    int DNATEMP;
    public void SetDNA(DNA EnumDNA)
    {
        RandomNUMBER = Random.Range(0, 2);
        if (RandomNUMBER == 0)
        {
            DNATEMP = DNADicX[EnumDNA];
        }
        else
        {
            DNATEMP = DNADicY[EnumDNA];
        }
    }

    public void DNAtoBaby(int parentNumber)
    {
        if (parentNumber == 1)
        {
            SetDNA(DNA.Block1);
            Reproduce.DNA1XBaby = DNATEMP;
            SetDNA(DNA.Block2);
            Reproduce.DNA2XBaby = DNATEMP;
            SetDNA(DNA.Block3);
            Reproduce.DNA3XBaby = DNATEMP;
            SetDNA(DNA.Block4);
            Reproduce.DNA4XBaby = DNATEMP;
            SetDNA(DNA.Block5);
            Reproduce.DNA5XBaby = DNATEMP;
            SetDNA(DNA.Block6);
            Debug.Log("FIRST PARENT IS GO");
        }
        if (parentNumber == 2)
        {
            SetDNA(DNA.Block1);
            Reproduce.DNA1YBaby = DNATEMP;
            SetDNA(DNA.Block2);
            Reproduce.DNA2YBaby = DNATEMP;
            SetDNA(DNA.Block3);
            Reproduce.DNA3YBaby = DNATEMP;
            SetDNA(DNA.Block4);
            Reproduce.DNA4YBaby = DNATEMP;
            SetDNA(DNA.Block5);
            Reproduce.DNA5YBaby = DNATEMP;
            SetDNA(DNA.Block6);
            Debug.Log("TWO PARENTS IS GO");
            rebirthDNA();
        }
        ValidParent = false;
    }
    int rebirthTo1;
    int rebirthTo2;
    int rebirthTo3;
    int rebirthTo4;
    public void rebirthDNA()
    {
        //X is left, Y is right, each one provides 2 points total because that makes my math easier
        DNADicX[DNA.Block1] = Reproduce.DNA1XBaby; DNADicY[DNA.Block1] = Reproduce.DNA1YBaby; //1-2
        DNADicX[DNA.Block2] = Reproduce.DNA2XBaby; DNADicY[DNA.Block2] = Reproduce.DNA2YBaby; //2-3
        DNADicX[DNA.Block3] = Reproduce.DNA3XBaby; DNADicY[DNA.Block3] = Reproduce.DNA3YBaby; //3-4
        DNADicX[DNA.Block4] = Reproduce.DNA4XBaby; DNADicY[DNA.Block4] = Reproduce.DNA4YBaby; //4-1
        DNADicX[DNA.Block5] = Reproduce.DNA5XBaby; DNADicY[DNA.Block5] = Reproduce.DNA5YBaby; //1-3
        DNADicX[DNA.Block6] = Reproduce.DNA6XBaby; DNADicY[DNA.Block6] = Reproduce.DNA6YBaby; //2-4
                                                                                              //DNADicX[DNA.Block1] + DNADicY[DNA.Block1 is "left"
                                                                                              //(1 - DNADicX[DNA.Block1]) + (1 - DNADicY[DNA.Block1]) is "right"

        rebirthTo1 = DNADicX[DNA.Block1] + DNADicY[DNA.Block1] +
                    (1 - DNADicX[DNA.Block4]) + (1 - DNADicY[DNA.Block4]) +
                    DNADicX[DNA.Block5] + DNADicY[DNA.Block5];

        rebirthTo2 = (1 - DNADicX[DNA.Block1]) + (1 - DNADicY[DNA.Block1]) +
                    DNADicX[DNA.Block2] + DNADicY[DNA.Block2] +
                    DNADicX[DNA.Block6] + DNADicY[DNA.Block6];

        rebirthTo3 = (1 - DNADicX[DNA.Block2]) + (1 - DNADicY[DNA.Block2]) +
                    DNADicX[DNA.Block3] + DNADicY[DNA.Block3] +
                    (1 - DNADicX[DNA.Block5]) + (1 - DNADicY[DNA.Block5]);

        rebirthTo4 = (1 - DNADicX[DNA.Block3]) + (1 - DNADicY[DNA.Block3]) +
                    DNADicX[DNA.Block4] + DNADicY[DNA.Block4] +
                    (1 - DNADicX[DNA.Block6]) + (1 - DNADicY[DNA.Block6]);

        TargetSkill.RefreshSkills(rebirthTo1, rebirthTo2, rebirthTo3, rebirthTo4);
    }
}
