using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_1_Manager : MonoBehaviour
{
    public GameObject[] animals_1;
    bool goOut_1 = false;
    int i = 0;
    float goTimer = 0;
    //bool disappear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_1)
        {
            goTimer += Time.deltaTime;
            while(i < animals_1.Length)
            {
                if(goTimer % 10 == 0)
                {
                    Dead();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Stranger")
        {
            goOut_1 = true;
        }
    }

    void Dead()
    {
        Destroy(animals_1[i]);
        i++;
    }
}
