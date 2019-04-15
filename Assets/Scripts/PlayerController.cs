using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Movimiento
{

    int dañoAcumulado;
    int caloriasAcumuladas;
    int caloriasParaReducir = 100;
    int reduccionPorCalorias = 10;
    Fruta frutaQueCome;

    void Start () {
        direccion = transform.position;
        dañoAcumulado = 0;
        caloriasAcumuladas = 0;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();

        base.FixedUpdate();
    }

    /*private void recibirDaño(int daño) {
       dañoAcumulado += daño;
       if (dañoAcumulado >= 100) PlayerStats.restarVida();
    }*/

    public void aumentarCalorias(int calorias) {
        caloriasAcumuladas += calorias;
    }

    private void reducirDaño() {
        if(caloriasAcumuladas >= caloriasParaReducir) {
            dañoAcumulado -= reduccionPorCalorias;
            if(dañoAcumulado < 0) dañoAcumulado = 0;
            caloriasAcumuladas -= caloriasParaReducir;
            }

    }

    public void restablecerACero() {
        dañoAcumulado = 0;
    }

    private void OnTriggerStay2D(Collider2D colisionador) {
        if(colisionador.tag == "fruta" && Input.GetKey(KeyCode.Space)) {
            //frutaQueCome = colisionador.GetComponent<GameObject>().GetComponent<Fruta>();
            //frutaQueCome.Desaparecer(colisionador.gameObject);
            Destroy(colisionador.gameObject);
        }
    }

    public void morir() {
        SceneManager.LoadScene("SampleScene");
    }

    private void GetInput() {
        if (Input.GetKeyDown(KeyCode.A) && transform.position == direccion)
        {        // Left
            direccion += Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position == direccion)
        {        // Right
            direccion += Vector3.right;
        }
        if (Input.GetKeyDown(KeyCode.W) && transform.position == direccion)
        {        // Up
            direccion += Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position == direccion)
        {        // Down
            direccion += Vector3.down;
        }


    }

    
}
