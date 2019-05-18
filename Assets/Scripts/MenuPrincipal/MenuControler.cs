﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Salir()
    {
        Application.Quit();
    }
  
}