using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Movimiento
{
    // Update is called once per frame
    void Update()
    {
        GetInput();

        base.Update();
    }

    private void GetInput() {
        direccion = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                direccion += Vector2.left;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direccion += Vector2.right;
            }
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.S))
            {
                direccion += Vector2.down;
            }
            if (Input.GetKey(KeyCode.W))
            {
                direccion += Vector2.up;
            }
        }
    }
}
