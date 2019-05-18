using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesInvulnerable : Acciones {

	[Range(0f, 1000f)]
	public float velocidadDeParpadeo = 400f;
	public GameObject soundEffect;


	public override void RecibirDaño(int daño, PlayerController player) { }

	/// <summary>
	/// Esta función hace que el personaje parpadee a una velocidad variable
	/// </summary>
	/// <param name="velocidad">Velocidad a la que parpadea entre 0 y 1</param>
	private void ParpadeoVisual(float velocidad) {
        Color colorActual = gameObject.GetComponent<SpriteRenderer>().color;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(colorActual.r, colorActual.g, colorActual.b, ((Time.time * velocidad) % 255) / 255);
	}

	public override void FinalizarEstado(PlayerController player) {
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
	}

    private void Start()
    {

        ComenzarEfectoDeSonido();
    }

	public float getVelocidadDeParpadeo() {
		return this.velocidadDeParpadeo;
	}

	public void setVelocidadDeParpadeo(float velocidadDeParpadeo) {
		this.velocidadDeParpadeo = velocidadDeParpadeo;
	}

}
