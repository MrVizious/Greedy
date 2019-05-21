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
	[SerializeField]
	int maxVidas = 3;
	PlayerController player;

	private SonidosController controladorSonido;
	private MusicaController controladorMusica;
	[SerializeField] private bool soundsActive = true, musicActive = true;


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
		//audioNivel = GameObject.Find("audioNivel");
		Mathf.Clamp(numeroVidas, 0, 3);
		ObtainElementsOfScene();
	}

	public void ObtainElementsOfScene() {
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		controladorSonido = GameObject.Find("AudioSonidos").GetComponent<SonidosController>();
		controladorMusica = GameObject.Find("AudioNivel").GetComponent<MusicaController>();
	}

	/// <summary>
	/// Recibe el nombre de la escena que se quiere cargar y la carga si puede
	/// </summary>
	/// <param name="name"></param>
	public void ChangeToScene(string name) {
		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	/// <summary>
	/// Recibe el número de la escena que se quiere cargar y la carga si puede
	/// </summary>
	/// <param name="name"></param>
	public void ChangeToScene(int number) {
		SceneManager.LoadScene(name, LoadSceneMode.Single);
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

	public void setNumeroVidas(int numeroVidas) {
		this.numeroVidas = numeroVidas;
	}

	public void AumentarNumeroVida(int cantidad) {
		this.numeroVidas += cantidad;
		if (numeroVidas > maxVidas) numeroVidas = maxVidas;
	}
	public void DisminuirNumeroVida(int cantidad) {
		if (numeroVidas > 0) {
			controladorSonido.ActivarSonidoSufrirDanyo();
			this.numeroVidas -= cantidad;
		}
		if (numeroVidas == 0) {
			StartCoroutine(GameOver());
		}
	}

	IEnumerator GameOver() {
		controladorMusica.ActivarSonidoGameOver();
		player.GetComponent<Animator>().runtimeAnimatorController = player.GreedyMorir;
		player.Morir();
		yield return new WaitForSeconds(1.7f);
		ChangeToScene("GameOver");
	}

	public bool getSoundsActive() {
		return soundsActive;
	}
	public bool getMusicActive() {
		return musicActive;
	}

	public void setSoundsActive(bool value) {
		soundsActive = value;
	}
	public void setMusicActive(bool value) {
		musicActive = value;
	}

	public void changeSoundsActive() {
		soundsActive = !soundsActive;
	}
	public void changeMusicActive() {
		musicActive = !musicActive;
	}
}