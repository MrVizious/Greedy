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
	public bool arriba, abajo, derecha, izquierda, move;
	private Movimiento movimiento;
	public Acciones estado;
    [SerializeField]
	int duracionDefensa = 7;
	private GameManager gameManager;

    private SonidosController controladorSonido;

    public RuntimeAnimatorController GreedyUp;
	public RuntimeAnimatorController GreedyDown;
	public RuntimeAnimatorController GreedyLeft;
	public RuntimeAnimatorController GreedyRight;

	public RuntimeAnimatorController GreedyMorir;
    public RuntimeAnimatorController GreedyGanar;


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
        controladorSonido = GameObject.Find("AudioSonidos").GetComponent<SonidosController>();
    }

	void Update() {
		if (arriba) {
			movimiento.direccion = Vector2.up;
			animacionActual.runtimeAnimatorController = GreedyUp;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
                controladorSonido.ActivarSonidoLimites();
			} else controladorSonido.ActivarSonidoMover();
		} else if (abajo) {
			movimiento.direccion = Vector2.down;
			animacionActual.runtimeAnimatorController = GreedyDown;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
                controladorSonido.ActivarSonidoLimites();
            } else controladorSonido.ActivarSonidoMover();
		} else if (derecha) {
			movimiento.direccion = Vector2.right;
			animacionActual.runtimeAnimatorController = GreedyRight;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
                controladorSonido.ActivarSonidoLimites();
            } else controladorSonido.ActivarSonidoMover();
		} else if (izquierda) {
			movimiento.direccion = Vector2.left;
			animacionActual.runtimeAnimatorController = GreedyLeft;
			movimiento.SetRumbo(movimiento.direccion);
			if (movimiento.ChocaConLimite(movimiento.direccion)) {
                controladorSonido.ActivarSonidoLimites();
            } else controladorSonido.ActivarSonidoMover();
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

	private void CambiarAEstadoNormal() {
        FinalizarEstado();
		Destroy(estado);
		estado = gameObject.AddComponent<AccionesNormal>();
	}

	private void OnTriggerStay2D(Collider2D colisionador) {
		if (colisionador.tag == "fruta" && Input.GetKeyDown(KeyCode.Space)) {
			int caloriasConsumidas = colisionador.gameObject.GetComponent<Comestible>().Comer();
            AumentarCalorias(caloriasConsumidas);
            Destroy(colisionador.gameObject);
            controladorSonido.ActivarSonidoComer();
        }
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

    public bool GetPowerUp()
    {
        return powerUp;
    }
}
