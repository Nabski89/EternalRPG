using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLizard : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
{
    ButtonController controller = other.GetComponent<ButtonController>();

    if (controller != null)
    {
        controller.ChangeHealth(1);
    }
}

void OnTriggerStay2D(Collider2D other)
{
    ButtonController controller = other.GetComponent<ButtonController>();

    if (controller != null)
    {
        controller.SKILLTrigger(1);
    }
}

}