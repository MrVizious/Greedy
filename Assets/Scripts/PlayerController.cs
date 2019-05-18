﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Movimiento))]
public class PlayerController : MonoBehaviour {

	public int dañoAcumulado;
	public int caloriasAcumuladas;
	public int caloriasTotal;
	public int caloriasParaReducir = 100;
	public int reduccionPorCalorias = 10;
	private Fruta frutaQueCome;
	public bool arriba, abajo, derecha, izquierda, move;
	private Movimiento movimiento;
	public Acciones estado;
	Acciones defensa;
	int duracionDefensa;
	AudioSource audioPlayer;
	public AudioClip mover, comer, perderVida, ganarVida, limite;
	private GameManager gameManager;
	private GameObject barraObjeto;


	public RuntimeAnimatorController GreedyUp;
	public RuntimeAnimatorController GreedyDown;
	public RuntimeAnimatorController GreedyLeft;
	public RuntimeAnimatorController GreedyRight;

	public RuntimeAnimatorController GreedyMorir;

	public RuntimeAnimatorController GreedyIddleUp;
	public RuntimeAnimatorController GreedyIddleDown;
	public RuntimeAnimatorController GreedyIddleLeft;
	public RuntimeAnimatorController GreedyIddleRight;

	public Animator animacionActual;

    private bool powerUp;


	public void Start() {
		animacionActual = GetComponent<Animator>();
        powerUp = false;
		gameManager = GameManager.getGameManager();
		movimiento = GetComponent<Movimiento>();
		dañoAcumulado = 0;
		caloriasAcumuladas = 0;
		arriba = abajo = derecha = izquierda = false;
		estado = gameObject.AddComponent<AccionesNormal>();
		audioPlayer = GetComponent<AudioSource>();
		barraObjeto = GameObject.Find("BarraDeDanyo");
	}

	void Update() {
		if (arriba) {
			movimiento.direccion = Vector2.up;
			animacionActual.runtimeAnimatorController = GreedyUp;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
				audioPlayer.clip = limite;
				audioPlayer.Play();
			} else ActivarSonidoMover();
		} else if (abajo) {
			movimiento.direccion = Vector2.down;
			animacionActual.runtimeAnimatorController = GreedyDown;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
				audioPlayer.clip = limite;
				audioPlayer.Play();
			} else ActivarSonidoMover();
		} else if (derecha) {
			movimiento.direccion = Vector2.right;
			animacionActual.runtimeAnimatorController = GreedyRight;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
				audioPlayer.clip = limite;
				audioPlayer.Play();
			} else ActivarSonidoMover();
		} else if (izquierda) {
			movimiento.direccion = Vector2.left;
			animacionActual.runtimeAnimatorController = GreedyLeft;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
				audioPlayer.clip = limite;
				audioPlayer.Play();
			} else ActivarSonidoMover();
		}


		if (movimiento.EstaEnObjetivo()) {
			if (animacionActual.runtimeAnimatorController == GreedyUp) {
				animacionActual.runtimeAnimatorController = GreedyIddleUp;
			} else if (animacionActual.runtimeAnimatorController == GreedyDown) {
				animacionActual.runtimeAnimatorController = GreedyIddleDown;
			} else if (animacionActual.runtimeAnimatorController == GreedyRight) {
				animacionActual.runtimeAnimatorController = GreedyIddleRight;
			} else if (animacionActual.runtimeAnimatorController == GreedyLeft) {
				animacionActual.runtimeAnimatorController = GreedyIddleLeft;
			}
		}

		arriba = false;
		abajo = false;
		derecha = false;
		izquierda = false;
	}



	void ActivarSonidoMover() {
		audioPlayer.clip = mover;
		audioPlayer.Play();
	}

	void ActivarSonidoComer() {
		audioPlayer.clip = comer;
		audioPlayer.Play();
	}

	void ActivarSonidoPerderVida() {
		audioPlayer.clip = perderVida;
		audioPlayer.Play();
	}
	void ActivarSonidoGanarVida() {
		audioPlayer.clip = ganarVida;
		audioPlayer.Play();
	}

	private void CambiarAEstadoNormal() {
        FinalizarEstado();
		Destroy(estado);
		estado = gameObject.AddComponent<AccionesNormal>();
	}

	private void OnTriggerStay2D(Collider2D colisionador) {
		if (colisionador.tag == "fruta" && Input.GetKeyDown(KeyCode.Space)) {
			colisionador.gameObject.GetComponent<Fruta>().Desaparecer();
			ActivarSonidoComer();
		}
	}

	private void OnTriggerEnter2D(Collider2D colisionador) {
		if (colisionador.tag == "defensa") {
			ActivarSonidoGanarVida();
			Destroy(estado);
            powerUp = true;
			Destroy(colisionador.gameObject);
		} else
		if (colisionador.tag == "capsula") {
			ActivarSonidoGanarVida();
			RestablecerACero();
			Destroy(colisionador.gameObject);
		} else
		if (colisionador.tag == "corazon") {
			gameManager.AumentarNumeroVida(1);
			ActivarSonidoGanarVida();
			Destroy(colisionador.gameObject);
		}
	}


	public void RecibirDaño(int daño) {
		estado.RecibirDaño(daño, this);
	}

	public void AumentarCalorias(int calorias) {
		estado.AumentarCalorias(calorias, this);
	}

	public void ReducirDaño() {
		estado.ReducirDaño(this);
	}

	public void RestablecerACero() {
		estado.RestablecerACero(this);
	}

	public void Morir() {

		estado.Morir(this);
	}

    public void ActivarDefensa()
    {
        if (!powerUp) return;
        powerUp = false;
        CancelInvoke("CambiarAEstadoNormal");
        Destroy(estado);
        estado = gameObject.AddComponent<AccionesInvulnerable>();
        Invoke("CambiarAEstadoNormal", 7);
    }


	public void FinalizarEstado() {
		estado.FinalizarEstado(this);
	}

	public void SetIzquierdaTrue() {
		izquierda = true;
	}
	public void SetDerechaTrue() {
		derecha = true;
	}
	public void SetArribaTrue() {
		arriba = true;
	}
	public void SetAbajoTrue() {
		abajo = true;
	}

	/*public void SetComerTrue() {
		comer = true;
	}*/
}
