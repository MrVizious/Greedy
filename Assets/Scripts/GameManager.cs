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
    [SerializeField]
    int minVidas = 0;
    [SerializeField]
    int maxVidas = 3;
    PlayerController player;
    [SerializeField]
    AudioSource audioNivel;
    [SerializeField]
    AudioClip sonidoGameOver;



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
        numeroVidas = 3;
        controladorSonido = GetComponent<AudioSource>();
        //audioNivel = GameObject.Find("audioNivel");
        Mathf.Clamp(numeroVidas, 0, 3);
        player = GameObject.Find("Player").GetComponent<PlayerController>();
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
        if (numeroVidas > maxVidas) numeroVidas = maxVidas;
	}
	public void DisminuirNumeroVida(int cantidad) {
        if (numeroVidas > 0)
        {
            controladorSonido.clip = sonidoPerderVida;
            controladorSonido.Play();
            this.numeroVidas -= cantidad;
        }
        if(numeroVidas == 0)
        {
            StartCoroutine(GameOver());
        }
    }
    
    IEnumerator GameOver()
    {
        audioNivel.clip = sonidoGameOver;
        audioNivel.Play();
        player.GetComponent<Animator>().runtimeAnimatorController = player.GreedyMorir;
        player.Morir();
        yield return new WaitForSeconds(1.7f);
        ChangeToScene("GameOver");
    }
}