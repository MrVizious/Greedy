using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GameManager))]


public class Guardian : MonoBehaviour {
    Vector2 direccionElegida;
    Movimiento movimiento;

    public RuntimeAnimatorController guardianUp;
    public RuntimeAnimatorController guardianDown;
    public RuntimeAnimatorController guardianLeft;
    public RuntimeAnimatorController guardianRight;

    void Start() {
        movimiento = GetComponent<Movimiento>();
        CalculaDirRandom();
        movimiento.SetRumbo(direccionElegida);
        UpdateAnimatorController();
    }

    void Update() {
        if (movimiento.PuedeAvanzar(direccionElegida))
        {
             movimiento.SetRumbo(direccionElegida);
        }
        else {
            CalculaDirRandom();
            UpdateAnimatorController();
        }
        
    }

    void UpdateAnimatorController() {
        if (direccionElegida == Vector2.up) {
            transform.GetComponent<Animator>().runtimeAnimatorController = guardianUp;
        } else if (direccionElegida == Vector2.down) {
            transform.GetComponent<Animator>().runtimeAnimatorController = guardianDown;
        } else if (direccionElegida == Vector2.right) {
            transform.GetComponent<Animator>().runtimeAnimatorController = guardianRight;
        } else if (direccionElegida == Vector2.left) {
            transform.GetComponent<Animator>().runtimeAnimatorController = guardianLeft;
        } else {
            transform.GetComponent<Animator>().runtimeAnimatorController = guardianDown;
        }
    }

    void CalculaDirRandom() {
        int elegido = Random.Range(0, 4);
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

    void OnTriggerEnter2D(Collider2D colisionado)
    {
        if(colisionado.tag == "Player")
        {
            colisionado.gameObject.GetComponent<PlayerController>().RecibirDaño(100);
        }
    }
}
