using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPotion : MonoBehaviour
{
    // Start is called before the first frame update

    public image MaskHPot;
    float originalSizeH;
    public image MaskMPot;
    float originalSizeM;
    void Start()
    {
        originalSizeH = maskMana.rectTransform.rect.width;
        originalSizeM = maskMana.rectTransform.rect.width;
    }

    // Update is called once per frame

    public void UpdateUI(int charNum, int HealthPotNum, int ManaPotNum)
    {

        MaskHPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * HealthPotNum/3);
        MaskMPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * ManaPotNum/3);

    }
}