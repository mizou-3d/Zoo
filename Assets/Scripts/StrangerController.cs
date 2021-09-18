using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrangerController : MonoBehaviour
{
    GameObject[] doorPositions;

    Transform target;
    //float speed = 2.0f;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        doorPositions[0] = GameObject.Find("DoorPos1");
        doorPositions[1] = GameObject.Find("DoorPos2");
        doorPositions[2] = GameObject.Find("DoorPos3");
        doorPositions[3] = GameObject.Find("DoorPos4");
        doorPositions[4] = GameObject.Find("DoorPos5");

        if (this.transform.position.x < 0)
        {
            target = doorPositions[Random.Range(0, 2)].transform;
        }
        else
        {
            target = doorPositions[Random.Range(2, 5)].transform;
        }

        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
