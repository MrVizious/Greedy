﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public int numeroFrutas;
    public GameObject[] frutas;
    public GameObject GameController;

    public void Start()
    {
        frutas = GameObject.FindGameObjectsWithTag("fruta");
        numeroFrutas = frutas.Length;
    }

    // Update is called once per frame
    public void Update()
    {
        frutas = GameObject.FindGameObjectsWithTag("fruta");
        numeroFrutas = frutas.Length;
        NivelCompletado();
    }

    public void NivelCompletado()
    {
        if(numeroFrutas == 0)
        {   //TODO: cambiar de nivel, de momento se reinicia la escena
            //GameController.CambiarEscena();
            SceneManager.LoadScene("SampleScene");
        }
    }
}
