using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {
	public GameObject player;
	public PlayerController statsPlayer;
	public GameObject gameController;
	private GameManager gameManager;
	public string calorias, danyo, vidas, defensa;
	public Text textoCalorias, textoDanyo, textoVidas, textoDefensa;
	// Start is called before the first frame update
	void Start() {
		gameManager = GameManager.getGameManager();
		player = GameObject.FindGameObjectWithTag("Player");
		statsPlayer = player.GetComponent<PlayerController>();
		gameController = GameObject.Find("GameController");
		textoCalorias = this.transform.Find("Calorias").GetComponent<Text>();
		textoDanyo = this.transform.Find("Danyo").GetComponent<Text>();
		textoVidas = this.transform.Find("Vidas").GetComponent<Text>();
		textoDefensa = this.transform.Find("Defensa").GetComponent<Text>();
	}

	// Update is called once per frame
	void Update() {
		//TODO: mostrar las vidas
		textoCalorias.text = "Calorías: " + statsPlayer.caloriasAcumuladas;
		textoDanyo.text = "Daño: " + statsPlayer.dañoAcumulado;
		textoVidas.text = "Vidas: " + gameManager.getNumeroVidas();
		if (player.GetComponent<AccionesNormal>() == null) {
			textoDefensa.text = "Defensa: invulnerable";
		} else { textoDefensa.text = "Defensa: ninguna"; }
		//textoVidas = "Vidas" + gameController.GetComponent<GameController>().vidas;
	}
}
