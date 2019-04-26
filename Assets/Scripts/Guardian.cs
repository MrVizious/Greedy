using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
[RequireComponent(typeof(PlayerController))]
//[RequireComponent(typeof(Animator))]



public class Guardian : MonoBehaviour {
    Vector2 direccionElegida;
    Movimiento movimiento;
    public Transform objetivo;
    PlayerController player;
    //Animator animator;

    void Start() {
        movimiento = GetComponent<Movimiento>();
        player = GetComponent<PlayerController>();
        //animator = GetComponent<Animator>();


        CalculaDirRandom();
        movimiento.SetRumbo(direccionElegida);
    }

    //Si player esta dentro de su rango lo persigue,
    // si no, sigue su curso hasta que no pueda avanzar
    void Update() {
        //animator.SetFloat("Speed", movimiento.runSpeed);
        if (movimiento.PuedeAvanzar(direccionElegida))
        {
             movimiento.SetRumbo(direccionElegida);
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
                /*animator.SetBool("Down", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Up", true);*/
                break;
            case 1:
                direccionElegida = Vector2.down;
                /*animator.SetBool("Up", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", false);
                animator.SetBool("Down", true);*/
                break;
            case 2:
                direccionElegida = Vector2.right;
                /*animator.SetBool("Down", false);
                animator.SetBool("Up", false);
                animator.SetBool("Left", false);
                animator.SetBool("Right", true);*/
                break;
            case 3:
                direccionElegida = Vector2.left;
                /*animator.SetBool("Down", false);
                animator.SetBool("Up", false);
                animator.SetBool("Right", false);
                animator.SetBool("Left", true);*/
                break;
        }
    }

    /*public void SeguirObjetivo()
    {
        transform.position = Vector2.MoveTowards(transform.position, objetivo.position, Time.deltaTime * movimiento.runSpeed);
    }*/
}
