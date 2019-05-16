using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(GameManager))]
public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int numeroFrutas;
    [SerializeField]
    int numeroTrampas;
    [SerializeField]
    int numeroGuardianes;
    [SerializeField]
    int numeroGuardianesRapidos;

    public GameObject[] frutas;
    public GameObject gameController;
    public GameManager gameManager;
    SpawnerElementos spawner;
    string[] consumibles = { "fresa", "uva", "pimiento", "zanahoria" };

    public void Start()
    {
        gameManager = GameManager.getGameManager();

        spawner = GameObject.Find("SpawnerElementos").GetComponent<SpawnerElementos>();
        //Hay que ver que no se generen cerca de player
        spawner.SpawnearElementos(numeroGuardianes, "guardian");
        spawner.SpawnearElementos(numeroGuardianesRapidos, "guardianRapido");
        //spawner.GenerarGuardianes(numeroGuardianes, prefabGuardian);
        //spawner.GenerarGuardianes(numeroGuardianesRapidos, prefabGuardianRapido);
        foreach (string cons in consumibles)
        {
            spawner.SpawnearElementos(numeroFrutas / 4, cons);
        }
        //spawner.SpawnearElementos(numeroFrutas, prefabFruta);
        spawner.SpawnearElementos(numeroTrampas, "trampa");
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
        gameManager.SiguienteEscena();
    }
}
