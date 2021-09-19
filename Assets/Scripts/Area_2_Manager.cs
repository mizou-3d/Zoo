using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_2_Manager : MonoBehaviour
{

    public GameObject[] animals_2;
    bool goOut_2 = false;
    int i = 0;
    float goTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_2)
        {
            goTimer += Time.deltaTime;
            while(i < animals_2.Length)
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
        if (other.gameObject.tag == "Stranger")
        {
            goOut_2 = true;
        }
    }

    void Dead()
    {
        Destroy(animals_2[i]);
        i++;
    }
}
