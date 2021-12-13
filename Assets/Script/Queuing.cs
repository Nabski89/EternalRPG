using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queuing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


//When an activity hits max, call queue advance and it will push everything up in the queue so we move onto the next activity
string queue1 = "empty";
string queue2 = "empty";
string queue3 = "empty";
string queue4 = "empty";
string queue5 = "empty";

//These upgrades will need to be called from some kind of other resource or upgrade type file because the intent is that it's a structure you can build
int QueueUpgrade = 0;

    void QueueAdvance()
    {
    queue1 = queue2;
        queue2 = queue3;
        queue3 = "empty";
        if (QueueUpgrade == 1)
    {
            queue3 = queue4;
            queue4 = "empty";
            if (QueueUpgrade == 2)
    {
                queue4 = queue5;
                queue5 = "empty";
            }
        }
        //we could make a t3 upgrade that stores 1 and loops it back into 5
    }
}


//go to a travel lane, go to the center lane, go to travel lane, go into job
//maybe we could give buildings tags and search for TAG + UNOCCUPIED then they could assign that as the nearest thing
//or you could just assign it from that location?
/*
movement planning

get our current location
get our goal location

divide by left and right?
if( not horizontal with job and not in the middle)
{
send ourselves to the center
if to the left to right until 0
if to the right go left until 0
}

if at the center go up and down until we are in line

go to our job

go down the 1 to actually get to the job


*/
