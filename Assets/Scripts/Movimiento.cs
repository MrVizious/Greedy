﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movimiento : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    protected Vector3 direccion;
    protected bool arriba, abajo, derecha, izquierda;

    //protected RaycastHit2D hit;

    private void Start()
    {
        Debug.DrawRay(transform.position, direccion, Color.blue, 0.8f);

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
         transform.position = Vector3.MoveTowards(transform.position, direccion, Time.deltaTime * runSpeed);
              
    }

    bool PuedeAvanzar(Vector3 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 0.8f);
        Debug.DrawRay(transform.position, direccion, Color.blue, 0.8f);
        if (hit.collider.tag == "obstaculo") return false;
        return true;

    }
}
