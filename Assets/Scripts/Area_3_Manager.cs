using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_3_Manager : MonoBehaviour
{
    public List<GameObject> animals_3;
    bool goOut_3 = false;
    float goTimer = 0;
    float stayTimer;
    public static int animal3;
    [SerializeField] GameObject mark3;
    [SerializeField] AudioSource alart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("私は不審者。");
        if (goOut_3 && animals_3.Count > 0)
        {
            goTimer += Time.deltaTime;
            if (goTimer >= 5)
            {
                Destroy(animals_3[0]);
                animals_3.RemoveAt(0);
                goTimer = 0;
            }
        }
        animal3 = animals_3.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_3 = true;
                mark3.SetActive(true);
                alart.Play();
                stayTimer = 0;
            }
        }
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            goOut_3 = false;
            mark3.SetActive(false);
            alart.Stop();
        }
    }
}
