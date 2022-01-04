using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildShopButtons : MonoBehaviour
{
    public GameObject SmallRef;
    public GameObject MediumRef;
    public GameObject LargeRef;
    public GameObject XLRef;
    // Start is called before the first frame update
    public void Small()
    {
        ToggleAll(SmallRef);
    }
    public void Medium()
    {
        ToggleAll(MediumRef);
    }
    public void Large()
    {
        ToggleAll(LargeRef);
    }
    public void XL()
    {
        ToggleAll(XLRef);
    }
    void ToggleAll(GameObject TheOneWeWant)
    {
        SmallRef.SetActive(false);
        MediumRef.SetActive(false);
        LargeRef.SetActive(false);
        XLRef.SetActive(false);

        TheOneWeWant.SetActive(true);
    }
}
