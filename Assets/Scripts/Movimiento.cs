﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour {
	[SerializeField]
	public float runSpeed;
	[SerializeField]
	[RangeAttribute(0f, 1f)]
	private float anguloRaycast;
	private Vector3 posicionObjetivo;
	public Vector3 direccion;
	private int capasDeColision;


	private void Start() {
		capasDeColision = 1 << LayerMask.NameToLayer("obstaculo");
		posicionObjetivo = transform.position;

		if (runSpeed == null || runSpeed == 0f) runSpeed = 5f;
		if (anguloRaycast == null || anguloRaycast == 0) anguloRaycast = 0.35f;
	}

	// Update is called once per frame
	void FixedUpdate() {
		Move();
	}

	public void Move() {
		transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, Time.deltaTime * runSpeed);

	}

    



    /// <summary>
    /// Este método se encarga de comprobar con 3 raycasts que se pueda avanzar en una determinada dirección
    /// </summary>
    /// <param name="direccion">Vector2.up, down, left o right</param>
    /// <returns>True si no hay colisión con obstáculo, false si la hay y por tanto no se puede avanzar</returns>
    public bool PuedeAvanzar(Vector3 direccion) {
		RaycastHit2D hit1 = Physics2D.Raycast(transform.position, direccion, 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, direccion, Color.blue, 1.2f);
		RaycastHit2D hit2 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? -anguloRaycast : direccion.x, direccion.y == 0 ? -anguloRaycast : direccion.y), 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, new Vector2(direccion.x == 0 ? -anguloRaycast : direccion.x, direccion.y == 0 ? -anguloRaycast : direccion.y), Color.red, 1.2f);
		RaycastHit2D hit3 = Physics2D.Raycast(transform.position, new Vector2(direccion.x == 0 ? anguloRaycast : direccion.x, direccion.y == 0 ? anguloRaycast : direccion.y), 1.2f, capasDeColision);
		Debug.DrawRay(transform.position, new Vector2(direccion.x == 0 ? anguloRaycast : direccion.x, direccion.y == 0 ? anguloRaycast : direccion.y), Color.green, 1.2f);

		if (hit1.collider != null && hit1.collider.tag.Equals("obstaculo")) return false;
		if (hit2.collider != null && hit2.collider.tag.Equals("obstaculo")) return false;
		if (hit3.collider != null && hit3.collider.tag.Equals("obstaculo")) return false;
		return true;

	}

	/// <summary>
	/// Comprueba que en la dirección en la que se quiere mover no haya ningún obstáculo, y si es así, cambia el rumbo a esa casilla
	/// </summary>
	/// <param name="direccion">Vector2.up, down, right o left</param>
	public void SetRumbo(Vector2 direccion) {
		if (Vector2.Distance(transform.position, posicionObjetivo) <= 0.1 && PuedeAvanzar(direccion)) {
			//TODO: Comprobar que está a poca distancia de su goal para poder meter otro input
			posicionObjetivo = new Vector2(Mathf.Round(transform.position.x + direccion.x),
				Mathf.Round(transform.position.y + direccion.y));
		}
	}
}
