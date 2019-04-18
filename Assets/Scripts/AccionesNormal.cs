using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesNormal : Acciones
{
    public override void AumentarCalorias(int calorias, PlayerController player)
    {
        player.caloriasAcumuladas += calorias;
    }

    public override void Morir(PlayerController player)
    {
         SceneManager.LoadScene("SampleScene");
    }

    public override void RecibirDaño(int daño, PlayerController player)
    {
        player.dañoAcumulado = +daño;
        if (player.dañoAcumulado >= 100) PlayerStats.restarVida();
    }

    public override void ReducirDaño(PlayerController player)
    {
        if (player.caloriasAcumuladas >= player.caloriasParaReducir)
        {
            player.dañoAcumulado -= player.reduccionPorCalorias;
            if (player.dañoAcumulado < 0) player.dañoAcumulado = 0;
            player.caloriasAcumuladas -= player.caloriasParaReducir;
        }
    }

    public override void RestablecerACero(PlayerController player)
    {
         player.dañoAcumulado = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
