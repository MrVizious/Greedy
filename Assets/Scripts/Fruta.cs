using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private int caloriasFruta;
    public PlayerController jugador;

    // Start is called before the first frame update
    void Start()
    {
        caloriasFruta = 10;
        if (jugador == null)
        {
            jugador = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    public void Desaparecer()
    {
        //LevelController.RestarFruta();
        jugador.AumentarCalorias(caloriasFruta);
        Destroy(this.gameObject);

    }
}
