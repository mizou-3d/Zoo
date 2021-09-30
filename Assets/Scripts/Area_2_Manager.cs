using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_2_Manager : MonoBehaviour
{

    public List<GameObject> animals_2;
    bool goOut_2 = false;
    float goTimer = 0;
    float stayTimer;
    public static int animal2;
    [SerializeField] GameObject mark2;
    [SerializeField] AudioSource alart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("私は不審者。");
        if (goOut_2 && animals_2.Count > 0)
        {
            goTimer += Time.deltaTime;
            if (goTimer >= 5)
            {
                Destroy(animals_2[0]);
                animals_2.RemoveAt(0);
                goTimer = 0;
            }
        }
        animal2 = animals_2.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_2 = true;
                mark2.SetActive(true);
                alart.Play();
                stayTimer = 0;
            }
        }
        if (other.gameObject.tag == "Player" || Input.GetKeyDown(KeyCode.Z))
        {
            goOut_2 = false;
            mark2.SetActive(false);
            alart.Stop();
        }
    }
}
