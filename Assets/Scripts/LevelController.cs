using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    SpawnerElementos spawner;
    // Start is called before the first frame update
    [SerializeField]
    int numeroFrutas;
    [SerializeField]
    int numeroTrampas;
    [SerializeField]
    int numeroGuardianes;
    public GameObject[] frutas;
    public GameObject GameController;

    public void Start()
    {
        spawner = GameObject.Find("SpawnerElementos").GetComponent<SpawnerElementos>();
        spawner.GenerarGuardianes(numeroGuardianes);
        spawner.GenerarFrutas(numeroFrutas);
        spawner.GenerarTrampas(numeroTrampas);
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
            SceneManager.LoadScene("NivelPrueba");
        }
    }
}
