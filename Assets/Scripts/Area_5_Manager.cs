using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_5_Manager : MonoBehaviour
{
    public List<GameObject> animals_5;
    bool goOut_5 = false;
    float goTimer = 0;
    float stayTimer;
    public static int animal5;
    [SerializeField] GameObject mark5;
    [SerializeField] AudioSource alart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (goOut_5 && animals_5.Count > 0)
        {
            goTimer += Time.deltaTime;
            if (goTimer >= 5)
            {
                Destroy(animals_5[0]);
                animals_5.RemoveAt(0);
                goTimer = 0;
            }
        }
        animal5 = animals_5.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_5 = true;
                mark5.SetActive(true);
                alart.Play();
                stayTimer = 0;
            }
        }
        if (other.gameObject.tag == "Player" || Input.GetKeyDown(KeyCode.Z))
        {
            goOut_5 = false;
            mark5.SetActive(false);
            alart.Stop();
        }
    }
}
