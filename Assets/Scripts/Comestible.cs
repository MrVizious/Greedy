using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comestible : MonoBehaviour
{
    [SerializeField]
    private int caloriasFruta;

    public int Comer()
    {
        return caloriasFruta;
    }
}
