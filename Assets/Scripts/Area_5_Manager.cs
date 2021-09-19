using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_5_Manager : MonoBehaviour
{
    public GameObject[] animals_5;
    bool goOut_5 = false;
    int i = 0;
    float goTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_5)
        {
            goTimer += Time.deltaTime;
            while(i < animals_5.Length)
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
            goOut_5 = true;
        }
    }

    void Dead()
    {
        Destroy(animals_5[i]);
        i++;
    }
}
