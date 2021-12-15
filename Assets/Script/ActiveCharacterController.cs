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
}
