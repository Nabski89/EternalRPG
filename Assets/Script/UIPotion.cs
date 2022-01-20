using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPotion : MonoBehaviour
{
    // Start is called before the first frame update

    public Image MaskHPot;
    float originalSizeH;
    public Image MaskMPot;
    float originalSizeM;
    public int CharacterNumber;
    void Start()
    {
        originalSizeH = MaskHPot.rectTransform.rect.width;
        originalSizeM = MaskMPot.rectTransform.rect.width;
        UpdateUI(CharacterNumber, 0, 0);
    }
    // Update is called once per frame
    public void UpdateUI(int charNum, int HealthPotNum, int ManaPotNum)
    {
        if (charNum == CharacterNumber)
        {
            if (HealthPotNum <= 3)
            {
                MaskHPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeH * HealthPotNum / 3);
                MaskHPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSizeH / 2);
            }
            else
            {
                MaskHPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeH * HealthPotNum / 3);
                MaskHPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSizeH);
            }
            if (ManaPotNum <= 3)
            {
                MaskMPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeM * ManaPotNum / 3);
                MaskMPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSizeM / 2);
            }
            else
            {
                MaskMPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSizeM * ManaPotNum / 3);
                MaskMPot.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, originalSizeM);
            }
        }
    }
}