using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
public class Guardian : MonoBehaviour {
    Vector2 direccionElegida;
    Movimiento movimiento;

    void Start() {
        movimiento = GetComponent<Movimiento>();

        CalculaDirRandom();
        movimiento.SetRumbo(direccionElegida);
    }


    void Update() {
        if (movimiento.PuedeAvanzar(direccionElegida))
        {
            movimiento.SetRumbo(direccionElegida);
        }
        else {
            CalculaDirRandom();
        }
    }

    void CalculaDirRandom() {
        int elegido = Random.Range(0, 3);
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

}
