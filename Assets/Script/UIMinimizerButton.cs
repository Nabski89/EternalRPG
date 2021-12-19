using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMinimizerButton : MonoBehaviour
{
    public Image UIElement;
    float originalSize;
    int toggle = 1;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = UIElement.rectTransform.rect.width;
    }

    // Update is called once per frame
    public void Toggle()
    {
        if (toggle == 1)
        {
            Vector2 position = transform.position;
            position.y = position.y + 50;
            transform.position = position;
            toggle = 0;
        }
        else
        {
            Vector2 position = transform.position;
            position.y = position.y - 50;
            transform.position = position;
            toggle = 1;
        }
    }
}