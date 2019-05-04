using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccionesNormal : Acciones {

	public override void Morir(PlayerController player) {
		//TODO: de momento se reinicia la escena
		SceneManager.LoadScene("SampleScene");
	}

	public override void CambiarEstado(PlayerController player) {
        Debug.Log("juju");
	}
}
