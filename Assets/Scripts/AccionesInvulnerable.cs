using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesInvulnerable : Acciones {

	[Range(0f, 1000f)]
	public float velocidadDeParpadeo = 400f;
	private GameObject soundEffect;

	public override void AumentarCalorias(int calorias, PlayerController player) {
		player.caloriasAcumuladas += calorias;
	}

	public override void Morir(PlayerController player) { }

	public override void RecibirDaño(int daño, PlayerController player) { }

	public override void ReducirDaño(PlayerController player) {
		if (player.caloriasAcumuladas >= player.caloriasParaReducir) {
			player.dañoAcumulado -= player.reduccionPorCalorias;
			if (player.dañoAcumulado < 0) player.dañoAcumulado = 0;
			player.caloriasAcumuladas -= player.caloriasParaReducir;
		}
	}

	public override void RestablecerACero(PlayerController player) {
		player.dañoAcumulado = 0;
	}

	/// <summary>
	/// Esta función hace que el personaje parpadee a una velocidad variable
	/// </summary>
	/// <param name="velocidad">Velocidad a la que parpadea entre 0 y 1</param>
	private void ParpadeoVisual(float velocidad) {
		Color colorActual = gameObject.GetComponent<SpriteRenderer>().color;
		gameObject.GetComponent<SpriteRenderer>().color = new Color(colorActual.r, colorActual.g, colorActual.b, ((Time.time * velocidad) % 255) / 255);
		//Debug.Log("Cambiando alpha por " + (Time.time * velocidad) % 255);
	}

	public override void PrepararParaCambiarEstado() {
		Color colorActual = gameObject.GetComponent<SpriteRenderer>().color;
		AcabarEfectoDeSonido();
		GetComponent<SpriteRenderer>().color = new Color(colorActual.r, colorActual.g, colorActual.b, 1f);
	}

	private void ComenzarEfectoDeSonido() {
		soundEffect = Instantiate(Resources.Load<GameObject>("SoundEffectInvincible"));
	}

	private void AcabarEfectoDeSonido() {
		Destroy(soundEffect);
	}

	// Update is called once per frame
	void Update() {
		ParpadeoVisual(velocidadDeParpadeo);
		//Debug.Log("Alpha actual: " + gameObject.GetComponent<SpriteRenderer>().color.a);
	}

	private void Start() {

		ComenzarEfectoDeSonido();
	}

	public float getVelocidadDeParpadeo() {
		return this.velocidadDeParpadeo;
	}

	public void setVelocidadDeParpadeo(float velocidadDeParpadeo) {
		this.velocidadDeParpadeo = velocidadDeParpadeo;
	}

}
