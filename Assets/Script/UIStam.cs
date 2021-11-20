using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//include UnityEngine.UI to resize things (access the image line)
public class UIStam : MonoBehaviour
{
    //static means it's accessable from anything else using those same values and all uses the same memory space
    public static UIStam instance { get; private set; }

    public Image maskStam;
    float originalSize;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalSize = maskStam.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        maskStam.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}