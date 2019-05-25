using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private int level = 1;
	[SerializeField]
	private int numeroVidas = 3;
	[SerializeField]
	private AudioClip sonidoPerderVida;
	[SerializeField]
	int minVidas = 0;
	private AudioSource soundsSource, musicSource;
	private bool soundsActive = true, musicActive = true;
	int maxVidas = 3;
	PlayerController player;

	public static GameManager getGameManager() {
		return instance;
	}

	void Awake() {

		//Check if instance already exists
		if (instance == null)
			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

	}

	void Start() {
		Mathf.Clamp(numeroVidas, 0, 3);
		ObtainElementsOfScene();
	}

	public void ObtainElementsOfScene() {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		soundsSource = GameObject.Find("AudioSonidos").GetComponent<AudioSource>();
		if (!soundsActive) soundsSource.enabled = false;
		musicSource = GameObject.Find("AudioNivel").GetComponent<AudioSource>();
		if (!musicActive) musicSource.enabled = false;
	}

	public void ChangeToScene(string name) {
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	public void ChangeToScene(int number) {
		ChangeToScene(SceneManager.GetSceneAt(number).name);
	}


	public void SiguienteEscena() {
		string siguienteEscena = "";
		int numeroEscena = SceneManager.GetActiveScene().buildIndex;
		switch (numeroEscena) {
			case 0:
				siguienteEscena = "Nivel1";
				break;
			case 1:
				siguienteEscena = "Nivel2";
				break;
			case 2:
				siguienteEscena = "Nivel3";
				break;
			case 3:
				siguienteEscena = "Nivel4";
				break;
			case 4:
				siguienteEscena = "Final";
				break;
		}
		SceneManager.LoadScene(siguienteEscena, LoadSceneMode.Single);
	}

	public int getNumeroVidas() {
		return this.numeroVidas;
	}

	public void AumentarNumeroVida(int cantidad) {
		this.numeroVidas += cantidad;
		if (numeroVidas > maxVidas) numeroVidas = maxVidas;
	}
	public void DisminuirNumeroVida(int cantidad) {
		if (numeroVidas > 0) {
			soundsSource.gameObject.GetComponent<SonidosController>().ActivarSonidoSufrirDanyo();
			this.numeroVidas -= cantidad;
		}
		if (numeroVidas == 0) {
			StartCoroutine(GameOver());
		}
	}

	IEnumerator GameOver() {
		musicSource.gameObject.GetComponent<MusicaController>().ActivarSonidoGameOver();
		player.GetComponent<Animator>().runtimeAnimatorController = player.GreedyMorir;
		player.Morir();
		yield return new WaitForSeconds(1.7f);
		ChangeToScene("GameOver");
	}

	public void changeSoundsActive() {
		soundsSource.enabled = !soundsSource.enabled;
		soundsActive = !soundsActive;
	}
	public void changeMusicActive() {
		musicSource.enabled = !musicSource.enabled;
		musicActive = !musicActive;
	}

	public bool getMusicActive() {
		return musicActive;
	}
	public bool getSoundsActive() {
		return soundsActive;
	}
}