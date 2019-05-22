using System.Collections;
using UnityEngine;

//[RequireComponent(typeof(GameManager))]
public class LevelController : MonoBehaviour {
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

	private MusicaController controladorMusica;
	PlayerController player;

	public void Start() {
		gameManager = GameManager.getGameManager();
		gameManager.ObtainElementsOfScene();

		controladorMusica = GameObject.Find("AudioNivel").GetComponent<MusicaController>();
		player = GameObject.Find("Player").GetComponent<PlayerController>();

		if (!gameManager.getMusicActive()) GameObject.Find("AudioNivel").GetComponent<AudioSource>().enabled = false;
		if (!gameManager.getSoundsActive()) GameObject.Find("AudioSonidos").GetComponent<AudioSource>().enabled = false;

		spawner = GameObject.Find("SpawnerElementos").GetComponent<SpawnerElementos>();
		//Hay que ver que no se generen cerca de player
		spawner.SpawnearElementos(numeroGuardianes, "guardian");
		spawner.SpawnearElementos(numeroGuardianesRapidos, "guardianRapido");
		//spawner.GenerarGuardianes(numeroGuardianes, prefabGuardian);
		//spawner.GenerarGuardianes(numeroGuardianesRapidos, prefabGuardianRapido);
		foreach (string cons in consumibles) {
			spawner.SpawnearElementos(numeroFrutas / 4, cons);
		}
		//spawner.SpawnearElementos(numeroFrutas, prefabFruta);
		spawner.SpawnearElementos(numeroTrampas, "trampa");
	}

	// Update is called once per frame
	void Update() {
		frutas = GameObject.FindGameObjectsWithTag("fruta");
		numeroFrutas = frutas.Length;
		if (numeroFrutas == 0) {
			StartCoroutine(SiguienteNivel());
		}

	}

	IEnumerator SiguienteNivel() {
		if (controladorMusica.getAudioSonidos().clip != controladorMusica.getGanar()) controladorMusica.ActivarSonidoGanar();

		player.GetComponent<Animator>().runtimeAnimatorController = player.GreedyGanar;
		player.Morir();
		yield return new WaitForSeconds(4f);

		gameManager.SiguienteEscena();
	}
}
