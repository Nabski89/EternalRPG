using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPopulate : MonoBehaviour
{
    public GameObject Grass1;
    public GameObject Grass2;
    public GameObject Grass3;
    public GameObject Grass4;
    public GameObject Grass5;
    public GameObject Grass6;
    int grassnumber = 0;
    public int grasscount = 25;
    public float range = 40;
    private float locX;
    private float locY;
    private int grassType;
    // Start is called before the first frame update
    void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {
        if (grassnumber <= grasscount)
        {
            grassnumber += 1;

            //SPAWN A GRASS
            locX = Random.Range(0f, range); //x
            locY = Random.Range(0f, range); //y

            grassType = Random.Range(1, 6); //pick the grass type

            if (grassType == 1)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass1, new Vector3(locX, locY, 0), Quaternion.identity);
            }
            if (grassType == 2)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass2, new Vector3(locX, locY, 0), Quaternion.identity);
            }
            if (grassType == 3)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass3, new Vector3(locX, locY, 0), Quaternion.identity);
            }
            if (grassType == 4)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass4, new Vector3(locX, locY, 0), Quaternion.identity);
            }
            if (grassType == 5)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass5, new Vector3(locX, locY, 0), Quaternion.identity);
            }
            if (grassType == 6)
            {
                Vector2 position = transform.position;
                position.x = locX;
                position.y = locY;

                GameObject childGameObject = Instantiate(Grass6, new Vector3(locX, locY, 0), Quaternion.identity);
            }
        }
    }

}
