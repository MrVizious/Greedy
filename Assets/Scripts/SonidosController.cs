﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    AudioClip mover, comer, perderVida, ganarVida, limite;
    AudioSource audioSonidos;
    void Start()
    {
        audioSonidos = GetComponent<AudioSource>();
    }
    public void ActivarSonidoMover()
    {
        audioSonidos.clip = mover;
        audioSonidos.Play();
    }

    public void ActivarSonidoComer()
    {
        audioSonidos.clip = comer;
        audioSonidos.Play();
    }

    public void ActivarSonidoSufrirDanyo()
    {
        audioSonidos.clip = perderVida;
        audioSonidos.Play();
    }
    public void ActivarSonidoGanarVida()
    {
        audioSonidos.clip = ganarVida;
        audioSonidos.Play();
    }

    public void ActivarSonidoLimites()
    {
        audioSonidos.clip = limite;
        audioSonidos.Play();
    }
}
