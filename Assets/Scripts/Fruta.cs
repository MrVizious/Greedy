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
        caloriasFruta = 15;
        if(jugador == null)
        {
            jugador = GameObject.Find("Player").GetComponent<PlayerController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void Desaparecer() {
        //LevelController.RestarFruta();
        jugador.AumentarCalorias(caloriasFruta);
        Destroy(this.gameObject);
        
    }
}
