using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reproduce : MonoBehaviour
{
    public int DNA1X;
    public int DNA1Y;
    public int DNA2X;
    public int DNA2Y;


        public static Reproduce instance { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame

    public GameObject BabyPrefab;
    public int Parents;

    void OnTriggerEnter2D(Collider2D other)
    {
        ButtonController controller = other.GetComponent<ButtonController>();

        if (controller != null)
        {
            
                controller.babymakeing(1);

        }
    }



    void Update()
    {


        if (Parents == 2)
        {
            GameObject projectileObject = Instantiate(BabyPrefab);
            Parents = 0;
        }



    }
}
