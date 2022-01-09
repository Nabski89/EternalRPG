using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//we are going to use this to read what DNA we have, and update our model accordingly

public class KoboldBodyController : MonoBehaviour
{
    public SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteArray;

    public KoboldController TargetKobold;
    public KoboldDNA TargetKoboldDNA;

    public KoboldDNA.DNA DNABlock;

    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer.sprite = spriteArray[TargetKoboldDNA.DNADicX[DNABlock] + TargetKoboldDNA.DNADicY[DNABlock]];
    }
    public void RefreshBody()
    {
        m_SpriteRenderer.sprite = spriteArray[TargetKoboldDNA.DNADicX[DNABlock] + TargetKoboldDNA.DNADicY[DNABlock]];
        //because DNA can only be 1 or 0, when both are 1 you get option 2, 0/1 or 1/0 gets you option 1, both 0 gets you 0
    }
}
