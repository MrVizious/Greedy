using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosSpawner : Spawner
{

    [SerializeField]
    string elemento;

    public override void ObtenerElemento()
    {
        prefab = fabrica.GetConsumible(elemento);
    }

    public override void Start()
    {
        Invoke("GenerarElementos", Random.Range(0, 60));
    }
}
