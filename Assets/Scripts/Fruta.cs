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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      public void Desaparecer() {
        //TO DO: llamar a metodo RestarFruta de LevelController para saber cuando acaba un nivel
        //jugador.aumentarCalorias(caloriasFruta);
        Destroy(this.gameObject);
        
    }

    /*public int getCaloriasFruta() {
        return caloriasFruta;
    }*/ // Creo que no hace falta
}
