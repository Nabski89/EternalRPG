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
        Debug.Log("Fail Part nut ");
    }

    void Start()
    {
        Debug.Log("Fail Part thigh");
        originalSize = maskMana.rectTransform.rect.width;
        Debug.Log("Fail Part butt ");
    }

    public void SetValue(float value)
    {
        Debug.Log("Fail Part cut ");
        maskMana.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}