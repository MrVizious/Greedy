using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{
    [SerializeField]
    AudioClip gameOver;
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
}
