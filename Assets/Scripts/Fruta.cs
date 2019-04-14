using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruta : MonoBehaviour
{
    private int caloriasFruta;
    BoxCollider2D colisionadorFruta;
    PlayerController jugador;
    
    // Start is called before the first frame update
    void Start()
    {
        caloriasFruta = 10; //Por ejemplo
        colisionadorFruta = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void Desaparecer() {
        jugador.aumentarCalorias(caloriasFruta);
        Destroy(this.gameObject);
        
    }

    /*public int getCaloriasFruta() {
        return caloriasFruta;
    }*/ // Creo que no hace falta
}
