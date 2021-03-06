﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EstadoInvulnerable : Estado {

	[Range(0f, 1000f)]
	float velocidadDeParpadeo = 400f;
	GameObject soundEffect;


	public override void RecibirDaño(int daño, PlayerController player) { }

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

	void Update() {
		ParpadeoVisual(velocidadDeParpadeo);
	}

    private void Start()
    {
        ComenzarEfectoDeSonido();
    }

}
