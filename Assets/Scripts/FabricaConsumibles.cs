using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame

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
            default:
                return null;

        }
    }
}
