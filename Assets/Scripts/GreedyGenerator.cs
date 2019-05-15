using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedyGenerator : MonoBehaviour
{
    public GameObject greedyMenuPrefab;
    public float generatorTimer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateSomething", 0f, generatorTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateSomething()
    {
        Instantiate(greedyMenuPrefab, transform.position, Quaternion.identity);
    }
}
