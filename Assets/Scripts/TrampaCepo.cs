using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaCepo : MonoBehaviour
{
    [SerializeField]
    int dañoTrampa = 30;
    [SerializeField]
    float segundosRetardo= 0.5f;

    PlayerController player;
    
    void Start()
    {
        
    }

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
