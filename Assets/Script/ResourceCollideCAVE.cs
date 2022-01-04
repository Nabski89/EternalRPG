using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCollideCave : MonoBehaviour
{
    //this is just an add-on to the cave resource collider
    // Start is called before the first frame update

    public float ResourceProgress = 0;
    public float ResourceProgressReqd = 300;

    public float CaveProgress = 0;


    public ResourceEnum.Resource ResourceType;
    public KoboldSkillController.T1Skill SkillType;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //when you reach cave progress thresholds, it upgrades what you can dig from it
    //eventually downgrading a little the lower tier stuff
}
