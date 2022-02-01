using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIElementClamp : MonoBehaviour
{
    public GameObject UIElement1;
    public GameObject HPBar;
    public GameObject ManaBar;
    public GameObject FoodBar;
    // Start is called before the first frame update
    void Awake()
    {
        KoboldController MainBody = gameObject.GetComponent(typeof(KoboldController)) as KoboldController;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ScreenPos = Camera.main.WorldToScreenPoint(this.transform.position) - new Vector3(0, 100, 0);
        UIElement1.transform.position = ScreenPos;


//        if (MainBody.>.9*)
    }
}
