using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedyGenerator : MonoBehaviour
{
    public GameObject greedyMenuPrefab;
    public float generatorTimer = 2f;
    void Start()
    {
        InvokeRepeating("CreateSomething", 0f, generatorTimer);
    }

    void CreateSomething()
    {
        Instantiate(greedyMenuPrefab, transform.position, Quaternion.identity);
    }
}
