using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSpawner : Spawner
{
    [SerializeField]
    string elemento;
    public override void ObtenerElemento()
    {
        prefab = fabrica.GetConsumible(elemento);
    }

    public override void EncontrarSitioVacio()
    {
        bool posicionEncontrada = false;
        do
        {
            posicion = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            if (Physics2D.OverlapCircle(posicion, radioBusqueda, finalMask) == null && Physics2D.OverlapCircle(posicion, 5f,1 << LayerMask.NameToLayer("player")) == null) 
            {
                posicionEncontrada = true;
            }
        }
        while (!posicionEncontrada);
    }
}
