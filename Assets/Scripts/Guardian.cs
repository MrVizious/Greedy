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

    public RuntimeAnimatorController guardianUp;
    public RuntimeAnimatorController guardianDown;
    public RuntimeAnimatorController guardianLeft;
    public RuntimeAnimatorController guardianRight;

    void Start() {
        movimiento = GetComponent<Movimiento>();
        player = GetComponent<PlayerController>();
        //animator = GetComponent<Animator>();


        CalculaDirRandom();
        movimiento.SetRumbo(direccionElegida);

        UpdateAnimatorController();
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
