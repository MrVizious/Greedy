using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : Movimiento
{
    public void Start()
    {
        posicionObjetivo = transform.position;
        
        //transform.Rotate(randomDirection);
        
    }


    public void Update()
    {
        posicionObjetivo = (Vector2)transform.position + Vector2.left;
        Move(posicionObjetivo);
        
    }

    void CalculaMovimiento() {
        posicionObjetivo = new Vector3(Random.value, Random.value, Random.value);
    }

    private void OnTriggerEnter(Collider valla)
    {
        if (valla.tag == "obstaculo") {
            CalculaMovimiento();
        }
    }
}
