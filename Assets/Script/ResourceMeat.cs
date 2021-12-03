using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMeat : MonoBehaviour
{
public int ResourceProgress=0;
int ResourceMax=10;

    public static ResourceMeat instance { get; set; }
    void Awake()
    {
        instance = this;
    }
void OnTriggerEnter2D(Collider2D other)
{
    ButtonController controller = other.GetComponent<ButtonController>();

    if (controller != null)
    {
//This is just empty in case I decide I want to put something in it later as it is the template job
    }
}

void OnTriggerStay2D(Collider2D other)
{
    ButtonController controller = other.GetComponent<ButtonController>();

    if (controller != null)
    {
//        controller.SKILLTrigger(1); //this might be neat later?
    }

    ResourceProgress += 1;
    if (ResourceProgress > 60)
    {
        ResourceProgress = 0;
        //make sure to replace meat with whatever the resource type is
                            Debug.Log("GAIN 1");
        ResourceTracker.instance.ResourceGain(1,1);
    }
}
}