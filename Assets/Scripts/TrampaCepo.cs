using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaCepo : MonoBehaviour
{
    [SerializeField]
    int dañoTrampa;
    [SerializeField]
    float segundosRetardo;
    bool activada;
    PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D colisionado)
    {
        if(colisionado.tag == "Player")
        {
            StartCoroutine(Activacion());
            player = colisionado.gameObject.GetComponent<PlayerController>();
        }
    }

    void OnTriggerExit2D(Collider2D colisionado)
    {
        if (colisionado.tag == "Player")
        {
            player = null;
        }
    }

    IEnumerator Activacion()
    {
        yield return new WaitForSeconds(segundosRetardo);
        if(player!=null) player.RecibirDaño(dañoTrampa);
        Destroy(this.gameObject);
    }
}
