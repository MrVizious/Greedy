using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Acciones : MonoBehaviour {

    GameManager gameManager;
    // Start is called before the first frame update
    void Start() {
        gameManager = GameManager.getGameManager();
    }

	// Update is called once per frame
	void Update() {

	}
	public virtual void RecibirDaño(int daño, PlayerController player)
    {
        player.dañoAcumulado += daño;
        if (player.dañoAcumulado >= 100)
        {
            player.dañoAcumulado = 0;
            gameManager.DisminuirNumeroVida(1);
        }
    }
    public virtual void AumentarCalorias(int calorias, PlayerController player)
    {
        player.caloriasAcumuladas += calorias;
    }
	public virtual void ReducirDaño(PlayerController player)
    {
        if (player.caloriasAcumuladas >= player.caloriasParaReducir)
        {
            player.dañoAcumulado -= player.reduccionPorCalorias;
            if (player.dañoAcumulado < 0) player.dañoAcumulado = 0;
            player.caloriasAcumuladas -= player.caloriasParaReducir;
        }
    }
	public virtual void RestablecerACero(PlayerController player)
    {
        player.dañoAcumulado = 0;
    }
	public abstract void Morir(PlayerController player);
	public abstract void CambiarEstado(PlayerController player);

}
