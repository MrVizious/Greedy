using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public int tiempoInicial;
    public float aumentarTiempo = 1f;
    public Text myText;
    public float tiempoFrame = 0f;
    public float tiempoEnSegundos = 0f;
    public float escaladaDeTiempoAlPausar, escaladaDeTiempoAlIniciar;
    public bool estaPausado = false;
    public int minutos, segundos;
    public string textoDelReloj;
    // Start is called before the first frame update
    public void Start()
    {
        //Establecemos la escala de tiemo original
        escaladaDeTiempoAlIniciar = aumentarTiempo;

        //Obtener el texto
        myText = GetComponent<Text>();

        //Inicializamos la variable que acumula los tiempos de cada frame con el tiempo inicial
        tiempoEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoInicial);
    }
    // Update is called once per frame
    public void Update()
    {
        if (!estaPausado)
        {
            //Tiempo en cada frame considerando la escala del tiempo
            tiempoFrame = Time.deltaTime * aumentarTiempo;

            //Acumulación tiempo segundos
            tiempoEnSegundos += tiempoFrame;

            ActualizarReloj(tiempoEnSegundos);
        }
    }
    public void ActualizarReloj(float tiempoEnSegundos)
    {
        minutos = 0;
        segundos = 0;

        //El tiempo no puede ser negativo
        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        //Cálculo de minutos y segundos
        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        //Creal el texto del timer
        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        myText.text = textoDelReloj;
    }
    public void Pausar()
    {
        if (!estaPausado)
        {
            estaPausado = true;
            escaladaDeTiempoAlPausar = aumentarTiempo;
            aumentarTiempo = 0;
        }
    }
    public void Continuar()
    {
        if (estaPausado)
        {
            estaPausado = false;
            aumentarTiempo = escaladaDeTiempoAlPausar;
        }
    }
    public void ResetTimer()
    {
        estaPausado = false;
        aumentarTiempo = escaladaDeTiempoAlIniciar;
        tiempoEnSegundos = tiempoInicial;

        ActualizarReloj(tiempoEnSegundos);
    }
}