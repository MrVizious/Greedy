using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
public class PlayerController : MonoBehaviour {

	int dañoAcumulado;
	int caloriasAcumuladas;
	int caloriasParaReducir = 100;
	int reduccionPorCalorias = 10;
	Fruta frutaQueCome;
	bool comer;
	private bool arriba, abajo, derecha, izquierda;
	private Movimiento movimiento;


	void Start() {
		//posicionObjetivo = transform.position;
		movimiento = GetComponent<Movimiento>();
		dañoAcumulado = 0;
		caloriasAcumuladas = 0;
		arriba = abajo = derecha = izquierda = false;
	}


	// Update is called once per frame
	void Update() {
		if (arriba) {
			movimiento.SetRumbo(Vector2.up);
		} else if (abajo) {
			movimiento.SetRumbo(Vector2.down);
		} else if (derecha) {
			movimiento.SetRumbo(Vector2.right);
		} else if (izquierda) {
			movimiento.SetRumbo(Vector2.left);
		}
		if (frutaQueCome != null) {
			if (comer) {
				frutaQueCome.Desaparecer();
			}
		}

		arriba = false;
		abajo = false;
		derecha = false;
		izquierda = false;

		comer = false;

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

	public void SetComerTrue() {
		comer = true;
	}

	private void OnTriggerStay2D(Collider2D colisionador) {
		if (colisionador.tag == "fruta") {
			frutaQueCome = colisionador.gameObject.GetComponent<Fruta>();
		}
	}
}
