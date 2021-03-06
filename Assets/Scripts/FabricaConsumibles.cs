﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaConsumibles : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabFresa;
    [SerializeField]
    private GameObject prefabUva;
    [SerializeField]
    private GameObject prefabPimiento;
    [SerializeField]
    private GameObject prefabZanahoria;
    [SerializeField]
    private GameObject prefabGuardian;
    [SerializeField]
    private GameObject prefabGuardianRapido;
    [SerializeField]
    private GameObject prefabCorazon;
    [SerializeField]
    private GameObject prefabCapsula;
    [SerializeField]
    private GameObject prefabDefensa;
    [SerializeField]
    private GameObject prefabTrampa;

    public GameObject GetConsumible(string nombreConsumible) {
        switch (nombreConsumible) {
            case "fresa":
                return prefabFresa;
            case "uva":
                return prefabUva;
            case "pimiento":
                return prefabPimiento;
            case "zanahoria":
                return prefabZanahoria;
            case "guardian":
                return prefabGuardian;
            case "guardianRapido":
                return prefabGuardianRapido;
            case "corazon":
                return prefabCorazon;
            case "capsula":
                return prefabCapsula;
            case "defensa":
                return prefabDefensa;
            case "trampa":
                return prefabTrampa;
            default:
                return null;

        }
    }
}
