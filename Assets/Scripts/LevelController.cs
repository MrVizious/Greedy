using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour {

	int numeroFrutas;
	public GameObject[] frutas;
	public GameManager gameManager;

	private MusicaController controladorMusica;
	PlayerController player;

	public void Start() {
		gameManager = GameManager.getGameManager();
		gameManager.ObtainElementsOfScene();

		controladorMusica = GameObject.Find("AudioNivel").GetComponent<MusicaController>();
		player = GameObject.Find("Player").GetComponent<PlayerController>();
	}

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
