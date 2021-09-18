using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrangerSpawnerController : MonoBehaviour
{
    public GameObject stranger;
    public Vector3[] strangerSpawnPos;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 20, 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Generate()
    {
        Instantiate(stranger, strangerSpawnPos[Random.Range(0,strangerSpawnPos.Length)], transform.rotation);
    }
}
