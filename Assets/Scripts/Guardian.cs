using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
[RequireComponent(typeof(PlayerController))]

public class Guardian : MonoBehaviour {
    Vector2 direccionElegida;
    Movimiento movimiento;
    public Transform objetivo;
    PlayerController player;

    void Start() {
        movimiento = GetComponent<Movimiento>();
        player = GetComponent<PlayerController>();

        CalculaDirRandom();
        movimiento.SetRumbo(direccionElegida);
    }

    //Si player esta dentro de su rango lo persigue,
    // si no, sigue su curso hasta que no pueda avanzar
    void Update() {
        if (movimiento.PuedeAvanzar(direccionElegida))
        {
            /*if (objetivo != null)
            {
                Debug.Log("Siguiendo objetivo");
                //SeguirObjetivo();
                movimiento.SetRumbo(movimiento.direccion);
            }
            else {*/
                movimiento.SetRumbo(direccionElegida);
           // }
        }
        else {
            CalculaDirRandom();
        }
        
    }

    void CalculaDirRandom() {
        int elegido = Random.Range(0, 4);
        Debug.Log(elegido);
        switch (elegido) {
            case 0:
                direccionElegida = Vector2.up;
                break;
            case 1:
                direccionElegida = Vector2.down;
                break;
            case 2:
                direccionElegida = Vector2.right;
                break;
            case 3:
                direccionElegida = Vector2.left;
                break;
        }
    }

    /*public void SeguirObjetivo()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Time.deltaTime * movimiento.runSpeed);
    }*/
}
