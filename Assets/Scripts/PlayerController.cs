using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Movimiento
{

    int dañoAcumulado;
    int caloriasAcumuladas;
    int caloriasParaReducir = 100;
    int reduccionPorCalorias = 10;
    Fruta frutaQueCome;
    bool comer;

    void Start () {
        direccion = transform.position;
        dañoAcumulado = 0;
        caloriasAcumuladas = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (arriba && transform.position == direccion)
        {
            direccion = (Vector2) transform.position + Vector2.up;
        }
        else if (abajo && transform.position == direccion)
        {
            direccion = (Vector2) transform.position + Vector2.down;
        }
        else if (derecha && transform.position == direccion)
        {
            direccion = (Vector2) transform.position + Vector2.right;
        }
        else if (izquierda && transform.position == direccion)
        {
            direccion = (Vector2) transform.position + Vector2.left;
        }

        base.FixedUpdate();

        arriba = false;
        abajo = false;
        derecha = false;
        izquierda = false;

        comer = false;

    }


    public void SetIzquierdaTrue() {
        izquierda = true;
    }
    public void SetDerechaTrue()
    {
        derecha = true;
    }
    public void SetArribaTrue()
    {
        arriba = true;
    }
    public void SetAbajoTrue()
    {
        abajo = true;
    }

    public void SetComerTrue() {
        comer = true;
    }

    private void OnTriggerStay2D(Collider2D colisionador)
    {
        if (colisionador.tag == "fruta")
        {
            frutaQueCome = colisionador.gameObject.GetComponent<Fruta>();
        }
    }
    /*private void recibirDaño(int daño) {
       dañoAcumulado += daño;
       if (dañoAcumulado >= 100) PlayerStats.restarVida();
    }*/

    /*public void aumentarCalorias(int calorias) {
        caloriasAcumuladas += calorias;
    }

    private void reducirDaño() {
        if(caloriasAcumuladas >= caloriasParaReducir) {
            dañoAcumulado -= reduccionPorCalorias;
            if(dañoAcumulado < 0) dañoAcumulado = 0;
            caloriasAcumuladas -= caloriasParaReducir;
            }

    }

    public void RestablecerACero() {
        dañoAcumulado = 0;
    }

    

    public void morir() {
        SceneManager.LoadScene("SampleScene");
    }*/


}
