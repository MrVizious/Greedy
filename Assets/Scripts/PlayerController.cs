using System.Collections;
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
	
	public Acciones estado;
	[SerializeField]
	int duracionDefensa = 7;
	private GameManager gameManager;

	private SonidosController controladorSonido;

	public RuntimeAnimatorController GreedyMorir;
	public RuntimeAnimatorController GreedyGanar;

	private Collider2D frutaCollider = null;

	private bool powerUp;


	public void Start() {
		powerUp = false;
		gameManager = GameManager.getGameManager();
		movimiento = GetComponent<Movimiento>();
		dañoAcumulado = 0;
		caloriasAcumuladas = 0;
		
		estado = gameObject.AddComponent<AccionesNormal>();
		controladorSonido = GameObject.Find("AudioSonidos").GetComponent<SonidosController>();
	}

	void Update() {
		
	}

	private void CambiarAEstadoNormal() {
		FinalizarEstado();
		Destroy(estado);
		estado = gameObject.AddComponent<AccionesNormal>();
	}

	private void OnTriggerStay2D(Collider2D colisionador) {
		if (colisionador.tag == "fruta") {
			frutaCollider = colisionador;
		}
	}

	public void Comer() {
		if (frutaCollider == null) return;
		int caloriasConsumidas = frutaCollider.gameObject.GetComponent<Comestible>().Comer();
		AumentarCalorias(caloriasConsumidas);
		Destroy(frutaCollider.gameObject);
		controladorSonido.ActivarSonidoComer();
	}

	private void OnTriggerEnter2D(Collider2D colisionador) {
		if (colisionador.tag == "defensa") {
			controladorSonido.ActivarSonidoGanarVida();
			powerUp = true;
			Destroy(colisionador.gameObject);
		} else
		if (colisionador.tag == "capsula") {
			controladorSonido.ActivarSonidoGanarVida();
			RestablecerACero();
			Destroy(colisionador.gameObject);
		} else
		if (colisionador.tag == "corazon") {
			gameManager.AumentarNumeroVida(1);
			controladorSonido.ActivarSonidoGanarVida();
			Destroy(colisionador.gameObject);
		} else
		if (colisionador.tag == "fruta") {
			frutaCollider = colisionador;
		}
	}
	private void OnTriggerExit2D(Collider2D other) {
		if (other == frutaCollider) frutaCollider = null;
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

	public void ActivarDefensa() {
		if (!powerUp) return;
		FinalizarEstado();
		powerUp = false;
		CancelInvoke("CambiarAEstadoNormal");
		Destroy(estado);
		estado = gameObject.AddComponent<AccionesInvulnerable>();
		Invoke("CambiarAEstadoNormal", duracionDefensa);
	}


	public void FinalizarEstado() {
		estado.FinalizarEstado(this);
	}

	public bool GetPowerUp() {
		return powerUp;
	}
}
