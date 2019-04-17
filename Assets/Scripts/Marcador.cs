using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Marcador : MonoBehaviour {
	private int puntuacion;
	private Text text;

	private void Start() {
		puntuacion = 0;
		text = GetComponent<Text>();
		text.text = this.toString();
	}

	/// <summary>
	/// Recibe un valor que se añade al actual, sumándolo
	/// </summary>
	/// <param name="suma">Valor entero a sumar</param>
	public void sumarPuntuacion(int suma) {
		this.puntuacion += suma;
		text.text = this.toString();
	}

	/// <summary>
	/// Recibe un valor que se decrementa al actual, restándolo
	/// </summary>
	/// <param name="resta">Valor entero a restar</param>
	public void restarPuntuacion(int resta) {
		this.puntuacion -= resta;
		text.text = this.toString();
	}



	public int getPuntuacion() {
		return this.puntuacion;
	}
	public void setPuntuacion(int puntuacion) {
		this.puntuacion = puntuacion;
		text.text = this.toString();
	}
	public string toString() {
		return "" + puntuacion;
	}
}
