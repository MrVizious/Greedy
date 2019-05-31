using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
    [SerializeField]
	PlayerController playerController;
    Movimiento movimientoController;

	void Start() {
        movimientoController = GetComponent<Movimiento>();
	}

	void Update() {
		GetInput();
	}

	void GetInput() {
		if (Input.GetKeyDown(KeyCode.A)) {
            movimientoController.SetIzquierdaTrue();
		} else if (Input.GetKeyDown(KeyCode.D)) {
            movimientoController.SetDerechaTrue();
		} else if (Input.GetKeyDown(KeyCode.W)) {
            movimientoController.SetArribaTrue();
		} else if (Input.GetKeyDown(KeyCode.S)) {
            movimientoController.SetAbajoTrue();
		}


		if (Input.GetKeyDown(KeyCode.O)) {
			playerController.ActivarDefensa();
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			playerController.Comer();
		}

	}
}
