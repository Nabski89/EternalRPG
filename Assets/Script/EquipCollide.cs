using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCollide : MonoBehaviour
{
    public bool gear = false;
    public bool tool = false;
    public float GearScore = 1.0f;
    public KoboldEquipment.Tools ToolType;
    public KoboldEquipment.Gear GearType;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldController controller = other.GetComponent<KoboldController>();
        KoboldEquipment EquipController = other.GetComponent<KoboldEquipment>();

        if (controller != null)
        {

            if (gear == true)
            {
                if (EquipController.HaveGear == false)
                {
                    EquipController.HaveGear = true;
                    EquipController.GearDic[GearType] = GearScore;
                    EquipIt(controller.CharacterNumber);
                }
            }

            if (tool == true)
            {
                if (EquipController.HaveTool == false)
                {
                    EquipController.HaveTool = true;
                    EquipController.ToolDic[ToolType] = GearScore;
                    EquipIt(controller.CharacterNumber);
                }
            }
        }
    }
    void EquipIt(int CharNum)
    {
        Debug.Log("Pick Up Equipment");

        Vector2 position = transform.position;
        if (gear == true)
        {
            position.x = 0;
        }
        if (tool == true)
        {
            position.x = 1;
        }
        position.y = -20 + CharNum;
        transform.position = position;

        //make it into a child of the kobold and send it to the FUCKING SHADOW ZONE until we want to drop it again
    }
}
