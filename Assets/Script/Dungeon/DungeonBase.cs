using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonBase : MonoBehaviour
{
    //If I was smart I would convert these into a LIST and use something like
    // int prefabIndex = UnityEngine.Random.Range(0,prefabList.Count-1);

    public int RoomCount = 50;
    public GameObject Room0;
    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;

    public GameObject DOORKILLER;

    public int Rotate = 0;

    // Start is called before the first frame update
    void Start()
    {
 
    }

int cooldown = 0;
    void Update()
    {
        cooldown +=1;
       if (RoomCount > 1 && cooldown >5)
        {
cooldown = 0;
            //get a random room
            var Base = GetComponentsInChildren<RoomBase>();
            var ChildRoom = Base[Random.Range(0, Base.Length)];
            //then try to get a room spawner off that, should maybe have some kind of check to make sure that we have at least 1 option
            var Room = ChildRoom.GetComponentsInChildren<RoomOffshoot>();
            var RoomSpawner = Room[Random.Range(0, Room.Length)];
            if (Room.Length > 0)
            {
                //   int KidCount = Random.Range(0, this.transform.childCount);
                Debug.Log("There are currently this many rooms:" + ChildRoom + "out of " + Base.Length);
                // GameObject child = this.transform.GetChild(KidCount).gameObject;
                //  var ChildRoom = child.GetComponent<RoomBase>();
                RoomCount -= 1;

                int RoomType = Random.Range(0,4);
                Debug.Log("Spawning room " + Room + "at location " + this.transform.position);
                if (RoomType == 0)
                {
                    Instantiate(Room0, new Vector3(RoomSpawner.transform.position.x, RoomSpawner.transform.position.y, 0), Quaternion.identity, transform);
                }
                if (RoomType == 1)
                {
                    Instantiate(Room1, new Vector3(RoomSpawner.transform.position.x, RoomSpawner.transform.position.y, 0), Quaternion.identity, transform);
                }
                if (RoomType == 2)
                {
                    Instantiate(Room2, new Vector3(RoomSpawner.transform.position.x, RoomSpawner.transform.position.y, 0), Quaternion.identity, transform);
                }
                if (RoomType == 3)
                {
                    Instantiate(Room3, new Vector3(RoomSpawner.transform.position.x, RoomSpawner.transform.position.y, 0), Quaternion.identity, transform);
                }

                Instantiate(DOORKILLER, new Vector3((RoomSpawner.transform.position.x + RoomSpawner.transform.parent.position.x) / 2, (RoomSpawner.transform.position.y + RoomSpawner.transform.parent.position.y) / 2, 0), Quaternion.identity, transform);
                //                Instantiate(DOORKILLER, new Vector3(RoomSpawner.transform.position.x, RoomSpawner.transform.position.y, 0), Quaternion.identity, transform);
                // Quaternion.identity.z + 90 * SPIN
            }

        }
    }
}