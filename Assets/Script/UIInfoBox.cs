using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInfoBox : MonoBehaviour
{
    public bool locked = false;

    void Start()
    {
        gameObject.GetComponent<Text>().text = "YOU ARE A KOBOLD, CLEARLY NOT A ROBOT";
    }

    void SHOPCOSTS(float cost1, float cost2, float cost3, float cost4, float cost5)
    {
        if (cost1 == 0)
        {
            gameObject.GetComponent<Text>().text = "This is free!";
        }
        if (cost1 != 0)
        {
            gameObject.GetComponent<Text>().text = "This is costs" + cost1;
        }
    }


    public void signaltotheworldthatIhavedonesomething(string MouseOverText)
    {
        gameObject.GetComponent<Text>().text = MouseOverText;
    }

    void update()
    {

    }
}
