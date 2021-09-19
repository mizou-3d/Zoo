using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_4_Manager : MonoBehaviour
{
    public GameObject[] animals_4;
    bool goOut_4 = false;
    int i = 0;
    float goTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_4)
        {
            goTimer += Time.deltaTime;
            while(i < animals_4.Length)
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
            goOut_4 = true;
        }
    }

    void Dead()
    {
        Destroy(animals_4[i]);
        i++;
    }
}
