using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_4_Manager : MonoBehaviour
{
    public List<GameObject> animals_4;
    bool goOut_4 = false;
    float goTimer = 0;
    float stayTimer;
    public static int animal4;
    [SerializeField] GameObject mark4;
    [SerializeField] AudioSource alart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("私は不審者。");
        if (goOut_4 && animals_4.Count > 0)
        {
            goTimer += Time.deltaTime;
            if (goTimer >= 5)
            {
                Destroy(animals_4[0]);
                animals_4.RemoveAt(0);
                goTimer = 0;
            }
        }
        animal4 = animals_4.Count;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Stranger")
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= 10)
            {
                goOut_4 = true;
                mark4.SetActive(true);
                alart.Play();
                stayTimer = 0;
            }
        }
        if (other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Z))
        {
            goOut_4 = false;
            mark4.SetActive(false);
            alart.Stop();
        }
    }
}
