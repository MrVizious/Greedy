using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampaCepo : MonoBehaviour {
	[SerializeField]
	int dañoTrampa;
    [SerializeField]
    float segundosRetardo;
	[SerializeField]
	private Sprite spriteActivado;

	PlayerController player;


	void OnTriggerEnter2D(Collider2D colisionado) {
		if (colisionado.tag == "Player") {
			StartCoroutine(Activacion());
			player = colisionado.gameObject.GetComponent<PlayerController>();
		}
	}

	void OnTriggerExit2D(Collider2D colisionado) {
		if (colisionado.tag == "Player") {
			player = null;
		}
	}

	IEnumerator Activacion() {
		yield return new WaitForSeconds(segundosRetardo);
		if (player != null) player.RecibirDaño(dañoTrampa);
		gameObject.GetComponent<SpriteRenderer>().sprite = spriteActivado;
		yield return new WaitForSeconds(segundosRetardo);
		Destroy(this.gameObject);
	}
}
