using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_3_Manager : MonoBehaviour
{
    public GameObject[] animals_3;
    bool goOut_3 = false;
    int i = 0;
    float goTimer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_3)
        {
            goTimer += Time.deltaTime;
            while(i < animals_3.Length)
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
            goOut_3 = true;
        }
    }

    void Dead()
    {
        Destroy(animals_3[i]);
        i++;
    }
}
