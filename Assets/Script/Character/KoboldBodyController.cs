using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we are going to use this to read what DNA we have, and update our model accordingly

public class KoboldBodyController : MonoBehaviour
{
    public GameObject Horns1; public GameObject Horns2; public GameObject Horns3;
    public GameObject Hands1; public GameObject Hands2; public GameObject Hands3;
    public GameObject Frill1; public GameObject Frill2; public GameObject Frill3;
    public GameObject BodyCenter;

    public KoboldController TargetKobold;
    public KoboldDNA TargetKoboldDNA;

    // Start is called before the first frame update
    void Start()
    {
        RefreshBody();
        //        m_SpriteRenderer.sprite = spriteArray[TargetKoboldDNA.DNADicX[DNABlock] + TargetKoboldDNA.DNADicY[DNABlock]];


    }
    public void RefreshBody()
    {
        Horns1.SetActive(false);
        Horns2.SetActive(false);
        Horns3.SetActive(false);
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block1] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block1]) == 0) { Horns1.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block1] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block1]) == 1) { Horns2.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block1] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block1]) == 2) { Horns3.SetActive(true); }

        Hands1.SetActive(false);
        Hands2.SetActive(false);
        Hands3.SetActive(false);
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block2] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block2]) == 0) { Hands1.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block2] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block2]) == 1) { Hands2.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block2] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block2]) == 2) { Hands3.SetActive(true); }

        Frill1.SetActive(false);
        Frill2.SetActive(false);
        Frill3.SetActive(false);
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block3] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block3]) == 0) { Frill1.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block3] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block3]) == 1) { Frill2.SetActive(true); }
        if ((TargetKoboldDNA.DNADicX[KoboldDNA.DNA.Block3] + TargetKoboldDNA.DNADicY[KoboldDNA.DNA.Block3]) == 2) { Frill3.SetActive(true); }


        //        m_SpriteRenderer.sprite = spriteArray[TargetKoboldDNA.DNADicX[DNABlock] + TargetKoboldDNA.DNADicY[DNABlock]];
        //because DNA can only be 1 or 0, when both are 1 you get option 2, 0/1 or 1/0 gets you option 1, both 0 gets you 0
    }



}
