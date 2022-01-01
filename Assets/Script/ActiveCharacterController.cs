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

    public void ChangeActiveCharacter(int incoming)
    {
        CurrentCharacter = incoming;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { CurrentCharacter = 1;}
        if (Input.GetKeyDown(KeyCode.F2)) { CurrentCharacter = 2; }
        if (Input.GetKeyDown(KeyCode.F3)) { CurrentCharacter = 3; }
        if (Input.GetKeyDown(KeyCode.F4)) { CurrentCharacter = 4; }
        if (Input.GetKeyDown(KeyCode.F5)) { CurrentCharacter = 5; }
        if (Input.GetKeyDown(KeyCode.F6)) { CurrentCharacter = 6; }
        if (Input.GetKeyDown(KeyCode.F7)) { CurrentCharacter = 7; }
        if (Input.GetKeyDown(KeyCode.Escape)) { CurrentCharacter = 0; }                    
    }
    //TO DO UPDATE SOME UI ELEMENT WHEN YOU SELECT A CHARACTER
}
