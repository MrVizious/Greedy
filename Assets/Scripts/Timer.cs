using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float aumentarTiempo = 1f;
    public Text myText;
    public float tiempoFrame;
    public float tiempoEnSegundos = 0f;
    public int minutos, segundos;
    public string textoDelReloj;

    public void Start()
    {
        myText = GetComponent<Text>();
        ActualizarReloj();
    }

    public void Update()
    {
            tiempoFrame = Time.deltaTime * aumentarTiempo;
            tiempoEnSegundos += tiempoFrame;
            ActualizarReloj();
    }
    public void ActualizarReloj()
    {
        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        myText.text = textoDelReloj;
    }
}