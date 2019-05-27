using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijosSpawner : Spawner
{
    [SerializeField]
    string elemento;

    public override void ObtenerElemento()
    {
        prefab = fabrica.GetConsumible(elemento);
    }

}
