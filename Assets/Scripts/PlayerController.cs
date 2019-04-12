using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movimiento
{
    int dañoAcumulado;
    int caloriasAcumuladas;
    int caloriasParaReducir = 100;
    int reducirPorCalorias = 10;
    
    void Start () {
        daño = 0;
        calorias = 0;
    }
    
    void Update()
    {
        GetInput();

        base.Update();
    }
    
    private void recibirDaño(int daño) {
       dañoAcumulado =+ daño;
       if (dañoAcumulado >= 100) morir();
    }
    
    private void aumentarCalorias(int calorias) {
        caloriasAcumuladas =+ calorias;
    }
    
    private void reducirDaño() {
        if(caloriasAcumuladas >= caloriasParaReducir) {
            dañoAcumulado =- reducirPorCalorias;
            if(dañoAcumulado < 0) dañoAcumulado = 0;
            caloriasAcumuladas =- caloriasParaReducir;
            }
            
    }
       
        

    private void GetInput() {
        direccion = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                direccion += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direccion += Vector2.right;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.S))
            {
                direccion += Vector2.down;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direccion += Vector2.up;
            }
        }
    }
}
