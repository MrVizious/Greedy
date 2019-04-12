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
        transform.Translate(direccion * runSpeed * Time.deltaTime);
    }
}
