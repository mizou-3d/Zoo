using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrangerController : MonoBehaviour
{

    Transform target;
    float timer = 0;
    bool gohome = false;

    NavMeshAgent agent;
    public Animator strangerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] doorPositions = new GameObject[5];
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

        //target = doorPositions[Random.Range(0, doorPositions.Length)].transform;

        agent = GetComponent<NavMeshAgent>();
        strangerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        if (timer >= 10f || gohome)
        {
            strangerAnimator.SetBool("isOpen", false);
            target = GameObject.Find("BackPos").transform;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            strangerAnimator.SetBool("isOpen", true);
            timer += Time.deltaTime;
        }
        if(other.gameObject.name == "BackPos")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Q))
        {
            gohome = true;
        }
    }
}
