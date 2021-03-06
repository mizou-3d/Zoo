using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_1_Manager : MonoBehaviour
{
    public List<GameObject> animals_1;
    bool goOut_1 = false;
    float goTimer = 0;
    float stayTimer;
    public static int animal1;
    [SerializeField] GameObject mark1;
    [SerializeField] AudioSource alart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("私は不審者。");
        if (goOut_1 && animals_1.Count > 0)
        {
            goTimer += Time.deltaTime;
                if(goTimer >= 5)
                {
                Destroy(animals_1[0]);
                animals_1.RemoveAt(0);
                goTimer = 0;
                }
        }
        animal1 = animals_1.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_1 = true;
                mark1.SetActive(true);
                alart.Play();
                stayTimer = 0;
            }
        }
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            goOut_1 = false;
            mark1.SetActive(false);
            alart.Stop();
        }
    }
}
