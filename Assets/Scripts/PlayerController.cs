﻿using System.Collections;
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
        posicionObjetivo = transform.position;
        dañoAcumulado = 0;
        caloriasAcumuladas = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (arriba)
        {
            posicionObjetivo = (Vector2) transform.position + Vector2.up;
            direccion = Vector2.up;
        }
        else if (abajo)
        {
            posicionObjetivo = (Vector2) transform.position + Vector2.down;
            direccion = Vector2.down;
        }
        else if (derecha)
        {
            posicionObjetivo = (Vector2) transform.position + Vector2.right;
            direccion = Vector2.right;
        }
        else if (izquierda)
        {
            posicionObjetivo = (Vector2) transform.position + Vector2.left;
            direccion = Vector2.left;
        }

        if (comer) {
            frutaQueCome.Desaparecer();
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
}
