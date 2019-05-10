using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IConsumible))]
public class FabricaConsumibles : MonoBehaviour
{
    public IConsumible prefabFresa;
    public IConsumible prefabUva;
    public IConsumible prefabPimiento;
    public IConsumible prefabZanahoria;
    // Start is called before the first frame update
    void Start()
    {
        prefabFresa = GetComponent<Fresa>();
        prefabFresa = GetComponent<Uva>();
        prefabFresa = GetComponent<Pimiento>();
        prefabFresa = GetComponent<Zanahoria>();
    }

    // Update is called once per frame

    public IConsumible GetConsumible(string nombreConsumible) {
        switch (nombreConsumible) {
            case "fresa":
                return prefabFresa;
            case "uva":
                return prefabUva;
            case "pimiento":
                return prefabPimiento;
            case "zanahoria":
                return prefabZanahoria;
            default:
                return null;

        }
    }
}
