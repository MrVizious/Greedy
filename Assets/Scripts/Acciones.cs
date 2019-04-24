using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Acciones : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	public abstract void RecibirDaño(int daño, PlayerController player);
	public abstract void AumentarCalorias(int calorias, PlayerController player);
	public abstract void ReducirDaño(PlayerController player);
	public abstract void RestablecerACero(PlayerController player);
	public abstract void Morir(PlayerController player);
	public abstract void PrepararParaCambiarEstado();

}
