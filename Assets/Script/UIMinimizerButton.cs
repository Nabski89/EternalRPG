using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinimizerButton : MonoBehaviour
{
    public GameObject ToggleObject;
    public int toggle = 1;

    // 0 if the thing is starting "on"

    public void Toggle()
    {
        if (toggle == 1)
        {
            ToggleObject.SetActive(true);
            toggle = 0;
        }
        else
        {
            ToggleObject.SetActive(false);
            toggle = 1;
        }
    }
}