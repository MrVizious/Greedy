using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {
	[SerializeField] private Sprite mutedImage;
	[SerializeField] private Sprite soundImage;
	[SerializeField] private TypeOfSound typeOfSound;
	private GameManager gameManager;
	enum TypeOfSound {
		sounds,
		music
	}

	void Start() {
		gameManager = GameManager.getGameManager();
		PrepareSounds();
	}

	void PrepareSounds() {
		gameManager = GameManager.getGameManager();
		if (typeOfSound == TypeOfSound.sounds) {
			if (gameManager.getSoundsActive()) {
				this.gameObject.GetComponent<Image>().sprite = soundImage;
			} else {
				this.gameObject.GetComponent<Image>().sprite = mutedImage;
			}
		} else if (typeOfSound == TypeOfSound.music) {
			if (gameManager.getMusicActive()) {
				this.gameObject.GetComponent<Image>().sprite = soundImage;
			} else {
				this.gameObject.GetComponent<Image>().sprite = mutedImage;
			}
		}
	}

	void ChangeMuted() {
		if (this.gameObject.GetComponent<Image>().sprite == mutedImage) {
			this.gameObject.GetComponent<Image>().sprite = soundImage;
		} else {
			this.gameObject.GetComponent<Image>().sprite = mutedImage;
		}

		if (typeOfSound == TypeOfSound.sounds) gameManager.changeSoundsActive();
		else if (typeOfSound == TypeOfSound.music) gameManager.changeMusicActive();
	}

}
