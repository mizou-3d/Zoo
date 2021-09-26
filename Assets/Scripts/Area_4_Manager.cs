using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_4_Manager : MonoBehaviour
{
    public GameObject[] animals_4;
    bool goOut_4 = false;
    int i = 0;
    float goTimer = 0;
    float stayTimer;
    //bool disappear;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("私は不審者。");
        if (goOut_4)
        {
            goTimer += Time.deltaTime;
            if (goTimer >= 10)
            {
                Destroy(animals_4[i]);
                i++;
                goTimer = 0;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_4 = true;
            }
        }
    }
}
