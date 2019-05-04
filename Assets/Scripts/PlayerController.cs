using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
public class PlayerController : MonoBehaviour {

	public int dañoAcumulado;
	public int caloriasAcumuladas;
	public int caloriasParaReducir = 100;
	public int reduccionPorCalorias = 10;
	private Fruta frutaQueCome;
	public bool arriba, abajo, derecha, izquierda;
	private Movimiento movimiento;
	public Acciones estado;
	Acciones defensa;
	int duracionDefensa;
	AudioSource audioPlayer;
	public AudioClip mover, comer, perderVida, ganarVida;
    private GameManager gameManager;

	public void Start() {
        gameManager = GameManager.getGameManager();
        movimiento = GetComponent<Movimiento>();
		dañoAcumulado = 0;
		caloriasAcumuladas = 0;
		arriba = abajo = derecha = izquierda = false;
		estado = gameObject.AddComponent<AccionesNormal>();
		audioPlayer = GetComponent<AudioSource>();
	}

	void Update() {
		if (arriba) {
			movimiento.direccion = Vector2.up;
			movimiento.SetRumbo(movimiento.direccion);
			ActivarSonidoMover();
		} else if (abajo) {
			movimiento.direccion = Vector2.down;
			movimiento.SetRumbo(movimiento.direccion);
			ActivarSonidoMover();
		} else if (derecha) {
			movimiento.direccion = Vector2.right;
			movimiento.SetRumbo(movimiento.direccion);
			ActivarSonidoMover();
		} else if (izquierda) {
			movimiento.direccion = Vector2.left;
			movimiento.SetRumbo(movimiento.direccion);
			ActivarSonidoMover();
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
		Destroy(estado);
		estado = gameObject.AddComponent<AccionesNormal>();
	}

	/*public void CambiarAEstadoInvulnerable() {
		CancelInvoke("CambiarAEstadoNormal");
		estado.PrepararParaCambiarEstado();
		//Destroy(estado);
		Destroy(estado); //Necesario para el test, Destroy() no deja.
		estado = gameObject.AddComponent<AccionesInvulnerable>();
		Invoke("CambiarAEstadoNormal", 7);
	}*/

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
            estado = colisionador.gameObject.GetComponent<AccionesInvulnerable>();
			Destroy(colisionador.gameObject);
            CambiarEstado();
            Invoke("CambiarAEstadoNormal", 7);
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

    public void CambiarEstado()
    {
        estado.CambiarEstado(this);
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
