using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour {
	[SerializeField]
	AudioClip gameOver, ganar;
	AudioSource audioSonidos;
	void Start() {
		audioSonidos = GetComponent<AudioSource>();
	}
	public void ActivarSonidoGameOver() {
		audioSonidos.clip = gameOver;
		audioSonidos.Play();
	}

	public void ActivarSonidoGanar() {
		audioSonidos.clip = ganar;
		audioSonidos.Play();
	}

	public AudioClip getGameOver() {
		return gameOver;
	}
	public AudioClip getGanar() {
		return ganar;
	}
    public AudioSource getAudioSonidos()
    {
        return audioSonidos;
    }

}