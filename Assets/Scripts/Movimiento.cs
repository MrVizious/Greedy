using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    protected Vector3 posicionObjetivo;
    protected Vector3 direccion;
    protected bool arriba, abajo, derecha, izquierda;
    protected Vector3 direccionGuardian;

    //protected RaycastHit2D hit;

    private void Start()
    {
       

        if (runSpeed == 0f) {
            runSpeed = 5f;
        }
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()

    {
        if (PuedeAvanzar(direccion))
        {
            Move();
        }
    }

    public void Move() {
         transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, Time.deltaTime * runSpeed);
              
    }

    public void Move(Vector3 direccionG) {
        transform.position = Vector3.MoveTowards(transform.position, direccionG, Time.deltaTime * runSpeed);
    }

    bool PuedeAvanzar(Vector3 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 0.6f);
        Debug.DrawRay(transform.position, direccion, Color.blue, 0.6f);
        if (hit.collider != null) {
            if (hit.collider.tag == "obstaculo") {
                Debug.Log(hit.collider.tag);
                return false;
            }
        } 
        return true;

    }
}
