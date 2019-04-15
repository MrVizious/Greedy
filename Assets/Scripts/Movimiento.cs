using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movimiento : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    protected Vector3 direccion;
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
        //if (PuedeAvanzar(direccion))
       // {
            Move();
        //}
    }

    public void Move() {
         transform.position = Vector3.MoveTowards(transform.position, direccion, Time.deltaTime * runSpeed);
              
    }

    bool PuedeAvanzar(Vector3 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 1.2f);
        if (hit.collider.tag.Equals("obstaculo")) return false;
        return true;

    }
}
