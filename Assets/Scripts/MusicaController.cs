using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    [SerializeField]
    AudioClip gameOver, ganar;
    AudioSource audioSonidos;
    void Start()
    {
        audioSonidos = GetComponent<AudioSource>();
    }
    public void ActivarSonidoGameOver()
    {
        audioSonidos.clip = gameOver;
        audioSonidos.Play();
    }

    public void ActivarSonidoGanar() {
        Debug.Log("Me cago en dios");
        audioSonidos.clip = ganar;
        audioSonidos.Play();
    }
}
