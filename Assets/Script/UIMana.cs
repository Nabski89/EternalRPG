using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//include UnityEngine.UI to resize things (access the image line)
public class UIMana : MonoBehaviour
{
    //static means it's accessable from anything else using those same values and all uses the same memory space
    public static UIMana instance { get; private set; }

    public Image maskMana;
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = maskMana.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        maskMana.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}