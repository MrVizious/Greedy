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
        int sentidoHorizontal = (int) Input.GetAxis("Horizontal");
        int sentidoVertical = (int) Input.GetAxis("Vertical");
        if (sentidoHorizontal !=0)
        {
            if (sentidoHorizontal > 0)
            {
                direccion = Vector2.left;
            }
            else
            {
                direccion = Vector2.right;
            }
        }
        else if (sentidoVertical != 0)
        {
            if (sentidoVertical < 0)
            {
                direccion = Vector2.down;
            }
            else
            {
                direccion = Vector2.up;
            }
        }


    }

    
}
