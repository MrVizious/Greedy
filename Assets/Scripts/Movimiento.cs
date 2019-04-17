using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    protected Vector3 posicionObjetivo;
    protected Vector3 direccion;
    protected Vector3 direccionGuardian;

    private int capasQueColisionan;

    //protected RaycastHit2D hit;

    private void Start()
    {
        capasQueColisionan = 1 << LayerMask.NameToLayer("obstaculo");
        posicionObjetivo = transform.position;

        if (runSpeed == 0f) {
            runSpeed = 5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         Move();
    }

    public void Move() {
         transform.position = Vector3.MoveTowards(transform.position, posicionObjetivo, Time.deltaTime * runSpeed);
              
    }

    public void Move(Vector3 direccionG) {
        transform.position = Vector3.MoveTowards(transform.position, direccionG, Time.deltaTime * runSpeed);
    }

    bool PuedeAvanzar(Vector3 direccion)
    {
        Debug.Log("Comprobando si puede avanzar");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direccion, 0.6f, capasQueColisionan);
        Debug.DrawRay(transform.position, direccion, Color.blue, 0.6f);
        if (hit.collider != null) {
            Debug.Log("No puede avanzar, ha chocado con: " + hit.collider.tag);
            if (hit.collider.tag == "obstaculo") {
                return false;
            }
        }
        Debug.Log("Puede avanzar");
        return true;

    }

    public void SetRumbo(Vector2 direccion) {
        if (PuedeAvanzar(direccion)) {
            posicionObjetivo = new Vector2(Mathf.Round(transform.position.x + direccion.x),
                Mathf.Round(transform.position.y + direccion.y));
        }
    }
}
