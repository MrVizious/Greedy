using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	private int level = 1;
	[SerializeField]
	private int numeroVidas = 3;
    private AudioSource controladorSonido;
    [SerializeField]
    private AudioClip sonidoPerderVida;


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

    void Start()
    {
        controladorSonido = GetComponent<AudioSource>();
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

	public int getNumeroVidas() {
		return this.numeroVidas;
	}

	public void setNumeroVidas(int numeroVidas) {
		this.numeroVidas = numeroVidas;
	}

	public void AumentarNumeroVida(int cantidad) {
		this.numeroVidas += cantidad;
	}
	public void DisminuirNumeroVida(int cantidad) {
        controladorSonido.clip = sonidoPerderVida;
        controladorSonido.Play();
		this.numeroVidas -= cantidad;
	}

}