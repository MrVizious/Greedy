using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionMenu : MonoBehaviour
{
    public float velocidad = 2f;
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.right * velocidad;
    }

}
