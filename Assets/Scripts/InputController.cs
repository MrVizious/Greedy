using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {
	public PlayerController playerController;

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		GetInput();
	}

	void GetInput() {
		if (Input.GetKey(KeyCode.A)) {
			playerController.SetIzquierdaTrue();
		} else if (Input.GetKey(KeyCode.D)) {
			playerController.SetDerechaTrue();
		} else if (Input.GetKey(KeyCode.W)) {
			playerController.SetArribaTrue();
		} else if (Input.GetKey(KeyCode.S)) {
			playerController.SetAbajoTrue();
		}


		/*if (Input.GetKeyDown(KeyCode.Space)) {
			playerController.SetComerTrue();
		}*/


	}
}
