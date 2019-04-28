using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invulnerable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D colisionador)
    {
        if(colisionador.tag == "Player")
        {
            colisionador.gameObject.GetComponent<PlayerController>().CambiarAEstadoInvulnerable();
        }
    }

}
