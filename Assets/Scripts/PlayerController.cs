using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movimiento))]
public class PlayerController : MonoBehaviour {

	public int dañoAcumulado;
    public int caloriasAcumuladas;
    public int caloriasParaReducir = 100;
    public int reduccionPorCalorias = 10;
	Fruta frutaQueCome;
	bool comer;
	public bool arriba, abajo, derecha, izquierda;
	private Movimiento movimiento;
    public Acciones estado;
    Acciones defensa;
    int duracionDefensa;

	public void Start() {
		//posicionObjetivo = transform.position;
		movimiento = GetComponent<Movimiento>();
		dañoAcumulado = 0;
		caloriasAcumuladas = 0;
		arriba = abajo = derecha = izquierda = false;
        estado = new GameObject().AddComponent<AccionesNormal>();
	}


	// Update is called once per frame
	void Update() {
		if (arriba) {
            movimiento.direccion = Vector2.up;
			movimiento.SetRumbo(movimiento.direccion);
		} else if (abajo) {
            movimiento.direccion = Vector2.down;
            movimiento.SetRumbo(movimiento.direccion);
		} else if (derecha) {
            movimiento.direccion = Vector2.right;
            movimiento.SetRumbo(movimiento.direccion);
		} else if (izquierda) {
            movimiento.direccion = Vector2.left;
            movimiento.SetRumbo(movimiento.direccion);
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

    private void VolverAEstadoNormal()
    {
        estado = new GameObject().AddComponent<AccionesNormal>();
    }
	private void OnTriggerStay2D(Collider2D colisionador) {
		if (colisionador.tag == "fruta") {
			frutaQueCome = colisionador.gameObject.GetComponent<Fruta>();
		} else
        if(colisionador.tag == "defensa")
        {
            defensa = colisionador.gameObject.GetComponent<Acciones>();
            Destroy(colisionador.gameObject);
        } else
        if (colisionador.tag == "capsula")
        {
            RestablecerACero();
            Destroy(colisionador.gameObject);
        } else
        if (colisionador.tag == "corazon")
        {
            //PlayerStats.SumarVida();
            Destroy(colisionador.gameObject);
        }
    }

    private void UsarDefensa()
    {
        CancelInvoke("VolverAEstadoNormal");
        estado = defensa;
        Invoke("VolverAEstadoNormal", duracionDefensa);
    }

    public void RecibirDaño(int daño)
    {
        estado.RecibirDaño(daño, this);
    }

    public void AumentarCalorias(int calorias)
    {
        estado.AumentarCalorias(calorias, this);
    }

    public void ReducirDaño()
    {
        estado.ReducirDaño(this);
    }

    public void RestablecerACero()
    {
        estado.RestablecerACero(this);
    }

    public void Morir()
    {
        estado.Morir(this);
    }
}
