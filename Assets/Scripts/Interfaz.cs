using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour {
    public PlayerController statsPlayer;
    private GameManager gameManager;

    private int numeroVidas, maxVidas = 3;
    private GameObject[] vidas = new GameObject[3];
    private GameObject imagenDefensa;
    public string calorias, danyo;
    public Text textoCalorias, textoDefensa;
    public Image danyoImage;
    float maxDanyo = 100f;


    void Start()
    {
        vidas = GameObject.FindGameObjectsWithTag("imagenCorazon");
        imagenDefensa = GameObject.Find("Defensa");
        gameManager = GameManager.getGameManager();
        statsPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        textoCalorias = this.transform.Find("Calorias").GetComponent<Text>();
        textoDefensa = this.transform.Find("Defensa").GetComponent<Text>();
    }

    void Update()
    {
        textoCalorias.text = "Calorías: " + statsPlayer.caloriasTotal;
        ActualizarBarra(statsPlayer.dañoAcumulado);

        MostrarVidas(gameManager.getNumeroVidas());

        ActualizarDefensa();
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

    public void ActualizarBarra(float cantidad)
    {
        danyoImage.transform.localScale = new Vector2(cantidad / maxDanyo, 1);
    }

    private void ActualizarDefensa()
    {
        imagenDefensa.SetActive(statsPlayer.GetPowerUp());
    }
}
