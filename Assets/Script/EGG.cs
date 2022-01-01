using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EGG : MonoBehaviour
{
    public bool EggReady = true;
    public int hatchTimer = 30 * 30;
    public int rotTimer = 180 * 30;

    /* need to do a check to make sure these are unlocked
        public KoboldController Kobold6;
public KoboldController Kobold7;
*/
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hatchTimer -= 1;
        rotTimer -= 1;
        if (hatchTimer == 0)
        {
            hatchEgg();
            hatchTimer = 30 * 30;
        }
        if (rotTimer == 0)
        {
            foreach (var koboldDNA in GameObject.FindObjectsOfType<KoboldDNA>())
            {
                koboldDNA.ValidParent = true;
            }
            Destroy(gameObject);
        }
    }
    float x = 0f;
    float y = 0f;
    public void hatchEgg()
    {
        Vector2 position = transform.position;
        x = position.x;
        y = position.y;


        foreach (var kobold in GameObject.FindObjectsOfType<KoboldController>())
        {
            if (EggReady == true && kobold.Dead == true)
            {
                kobold.rebirth(x, y);

                foreach (var koboldDNA in GameObject.FindObjectsOfType<KoboldDNA>())
                {
                    koboldDNA.ValidParent = true;
                }
                Destroy(gameObject);
            }
        }
    }
}
