using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduce : MonoBehaviour
{
    //I know variables normally get their own lines but FUCK this should really be an array. First line is X, Second is Y. Alternating Mom/Dad/Baby

    //Health
    public int DNA1XBaby = 1;
    public int DNA1YBaby = 1;
    //Mana
    public int DNA2XBaby = 1;
    public int DNA2YBaby = 1;
    //Physical Skills
    public int DNA3XBaby = 1;
    public int DNA3YBaby = 1;
    //Magical Skills
    public int DNA4XBaby = 1;
    public int DNA4YBaby = 1;
    //Lifespan
    public int DNA5XBaby = 1;
    public int DNA5YBaby = 1;

    public int DNA6XBaby = 1;
    public int DNA6YBaby = 1;

    public static Reproduce instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public KoboldController Kobold1;
    public KoboldController Kobold2;
    public KoboldController Kobold3;
    public KoboldController Kobold4;
    public KoboldController Kobold5;

    /* need to do a check to make sure these are unlocked
        public KoboldController Kobold6;
public KoboldController Kobold7;
*/

    public int NumberOfParents = 0;
    public int DNATEMP;
    public int RandomNUMBER;

    public void SetDNA(int DNAX, int DNAY)
    {
        RandomNUMBER = Random.Range(0, 2);
        if (RandomNUMBER == 0)
        {
            DNATEMP = DNAX;
        }
        else
        {
            DNATEMP = DNAY;
        }
    }
    bool babyready = false;
    void rebirth(KoboldController KoboldNumber)
    {
        if (babyready == true)
        {
            if (KoboldNumber.Dead == true)
            {
                KoboldNumber.rebirth();
                babyready = false;
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        KoboldDNA controller = other.GetComponent<KoboldDNA>();
        if (controller != null)
        {
            if (NumberOfParents == 1)
            {
                Debug.Log("Second Parent");
                controller.DNAtoBaby(2);
                //THIS IS WHERE YOU WOULD SPAWN THE BABY, but we are reworking it so that it revives a dead kobold instead
                rebirth(Kobold1);
                rebirth(Kobold2);
                rebirth(Kobold3);
                rebirth(Kobold4);
                rebirth(Kobold5);
                /* need to do a check to make sure these are unlocked
                if()
                rebirth(Kobold6);
                rebirth(Kobold7);
*/

                NumberOfParents = 0;
            }
            if (NumberOfParents == 0)
            {
                Debug.Log("First Parent");
                controller.DNAtoBaby(1);
            }
        }


    }



}
