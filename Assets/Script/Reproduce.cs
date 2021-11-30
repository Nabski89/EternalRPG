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

    public static Reproduce instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public GameObject BabyPrefab;
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
    void OnTriggerEnter2D(Collider2D other)
    {
        ButtonController controller = other.GetComponent<ButtonController>();
        if (controller != null)
        {
            if (NumberOfParents == 1)
            {
                Debug.Log("Second Parent");
                controller.babymakeing(2);
                GameObject projectileObject = Instantiate(BabyPrefab);
                NumberOfParents = 0;
            }
            if (NumberOfParents == 0)
            {
                Debug.Log("First Parent");
                controller.babymakeing(1);
            }
        }
    }



    void Update()
    {






    }
}
