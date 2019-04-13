using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movimiento
{

    int dañoAcumulado;
    int caloriasAcumuladas;
    int caloriasParaReducir = 100;
    int reduccionPorCalorias = 10;
    CircleCollider2D colisionadorPlayer;

    void Start () {
        dañoAcumulado = 0;
        caloriasAcumuladas = 0;
        colisionadorPlayer = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate() {
        
    }

    // Update is called once per frame
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
            dañoAcumulado =- reduccionPorCalorias;
            if(dañoAcumulado < 0) dañoAcumulado = 0;
            caloriasAcumuladas =- caloriasParaReducir;
            }

    }

    public void restablecerACero() {
        dañoAcumulado = 0;
    }

    private void OnTriggerStay2D(Collider2D colisionador) {
        if(colisionador.tag == "fruta" && Input.GetKey(KeyCode.Space)) {
            colisionador.GameObject.desaparecer();
        }
    }

    private void GetInput() {
        direccion = Vector2.zero;
        int sentidoHorizontal = (int) Input.GetAxis("Horizontal");
        int sentidoVertical = (int) Input.GetAxis("Vertical");
        if (sentidoHorizontal !=0)
        {
            if (sentidoHorizontal < 0)
            {
                direccion = Vector2.left;
            }
            else
            {
                direccion = Vector2.right;
            }
        }
        else if (sentidoVertical != 0)
        {
            if (sentidoVertical < 0)
            {
                direccion = Vector2.down;
            }
            else
            {
                direccion = Vector2.up;
            }
        }


    }

    
}
