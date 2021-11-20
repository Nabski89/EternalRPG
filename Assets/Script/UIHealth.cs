using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//include UnityEngine.UI to resize things (access the image line)
public class UIHealth : MonoBehaviour
{
    //static means it's accessable from anything else using those same values and all uses the same memory space
    public static UIHealth instance { get; private set; }

    public Image maskHealth;
    float originalSize;

    void Awake()
    {
        instance = this;
        Debug.Log("Fail Part nut ");
    }

    void Start()
    {
        Debug.Log("Fail Part thigh");
        originalSize = maskHealth.rectTransform.rect.width;
        Debug.Log("Fail Part butt ");
    }

    public void SetValue(float value)
    {
        Debug.Log("Fail Part cut ");
        maskHealth.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }
}