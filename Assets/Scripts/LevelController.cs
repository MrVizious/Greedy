﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int numeroFrutas;
    [SerializeField]
    GameObject prefabFruta;
    [SerializeField]
    int numeroTrampas;
    [SerializeField]
    GameObject prefabTrampa;
    [SerializeField]
    int numeroGuardianes;
    [SerializeField]
    GameObject prefabGuardian;

    public GameObject[] frutas;
    public GameObject GameController;
    SpawnerElementos spawner;

    public void Start()
    {
        spawner = GameObject.Find("SpawnerElementos").GetComponent<SpawnerElementos>();
        //Hay que ver que no se generen cerca de player
        //spawner.SpawnearElementos(numeroGuardianes, prefabGuardian);
        spawner.GenerarGuardianes(numeroGuardianes, prefabGuardian);
        spawner.SpawnearElementos(numeroFrutas, prefabFruta);
        spawner.SpawnearElementos(numeroTrampas, prefabTrampa);
    }

    // Update is called once per frame
    public void Update()
    {
        frutas = GameObject.FindGameObjectsWithTag("fruta");
        numeroFrutas = frutas.Length;
        if(numeroFrutas==0) NivelCompletado();
    }

    public void NivelCompletado()
    {
        //TODO: cambiar de nivel, de momento se reinicia la escena
        //GameController.CambiarEscena();
        SceneManager.LoadScene("NivelPrueba");
    }
}
