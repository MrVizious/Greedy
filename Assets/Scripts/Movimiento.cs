using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movimiento : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    protected Vector2 direccion;

    private void Start()
    {
        if (runSpeed == 0f) {
            runSpeed = 5f;
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    public void Move() {
        if (puedeAvanzar(direccion)) {
            transform.Translate(direccion * runSpeed * Time.deltaTime);
        }
        
    }

    bool puedeAvanzar(Vector2 direccion)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 1.2f);
        if (hit.collider.tag.Equals("Obstaculo")) {
            return false;
        }
        return true;

    }
}
