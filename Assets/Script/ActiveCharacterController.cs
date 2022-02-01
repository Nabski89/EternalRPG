using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCharacterController : MonoBehaviour
{
    public static int CurrentCharacter = 1;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var koboldC in GameObject.FindObjectsOfType<KoboldController>())
            {
                koboldC.Selected = false;
            }
        }
    }
    //TO DO UPDATE SOME UI ELEMENT WHEN YOU SELECT A CHARACTER
}
