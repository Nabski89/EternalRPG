using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEdgeMove : MonoBehaviour
{
    public float side;
    public float top;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void move(float moveX, float moveY)
    {
        Debug.Log("TRYING TO CHANGE WORLD SIZE");
        Vector3 position = transform.position;
        position.x = (position.x + moveX * side);
        position.y = (position.y + moveY * top);
        transform.position = position;
    }
    
}
