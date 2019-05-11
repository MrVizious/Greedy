using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {
    public GameObject player;
    public PlayerController statsPlayer;
    public GameObject gameController;
    private GameManager gameManager;

    private int numeroVidas, maxVidas = 3;
    private GameObject[] vidas = new GameObject[3];

    public string calorias, danyo, defensa;
    public Text textoCalorias, textoDanyo, textoDefensa;
    public Image danyoImage;
    float danyoBarra, maxDanyo = 100f;

    // Start is called before the first frame update
    void Start()
    {
        vidas = GameObject.FindGameObjectsWithTag("imagenCorazon");
        gameManager = GameManager.getGameManager();
        player = GameObject.FindGameObjectWithTag("Player");
        statsPlayer = player.GetComponent<PlayerController>();
        gameController = GameObject.Find("GameController");
        textoCalorias = this.transform.Find("Calorias").GetComponent<Text>();
        textoDanyo = this.transform.Find("Danyo").GetComponent<Text>();
        textoDefensa = this.transform.Find("Defensa").GetComponent<Text>();
        danyoBarra = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: mostrar las vidas
        textoCalorias.text = "Calorías: " + statsPlayer.caloriasTotal;
        textoDanyo.text = "Daño: " + statsPlayer.dañoAcumulado;

        numeroVidas = gameManager.getNumeroVidas();
        MostrarVidas(numeroVidas);

        if (player.GetComponent<AccionesNormal>() == null)
        {
            textoDefensa.text = "Defensa: invulnerable";
        }
        else { textoDefensa.text = "Defensa: ninguna"; }
        //textoVidas = "Vidas" + gameController.GetComponent<GameController>().vidas;
    }

    void MostrarVidas(int vidasNumero)
    {
        int i;
        for(i = 0; i < vidasNumero; i++)
        {
            vidas[i].SetActive(true);
        }
        for(i = vidasNumero; i<maxVidas; i++)
        {
            vidas[i].SetActive(false);
        }
    }

    public void RecibirDaño(float cantidad)
    {
        danyoBarra = Mathf.Clamp(danyoBarra - cantidad, 0f, maxDanyo);
        danyoImage.transform.localScale = new Vector2(danyoBarra / maxDanyo, 1);
    }


}
