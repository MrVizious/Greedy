using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {
	[SerializeField] private Sprite mutedImage;
	[SerializeField] private Sprite soundImage;
	[SerializeField] private AudioSource audioPlayer;
	private GameManager gameManager;

	public void Start() {
		gameManager = GameManager.getGameManager();
		PrepareSounds();
	}

	public void PrepareSounds() {
		gameManager = GameManager.getGameManager();
		if (audioPlayer.gameObject.name.Equals("AudioSonidos")) {
			if (gameManager.getSoundsActive()) {
				this.gameObject.GetComponent<Image>().sprite = soundImage;
				audioPlayer.enabled = true;
			} else {
				this.gameObject.GetComponent<Image>().sprite = mutedImage;
				audioPlayer.enabled = false;
			}
		} else if (audioPlayer.gameObject.name.Equals("AudioNivel")) {
			if (gameManager.getMusicActive()) {
				this.gameObject.GetComponent<Image>().sprite = soundImage;
				audioPlayer.enabled = true;
			} else {
				this.gameObject.GetComponent<Image>().sprite = mutedImage;
				audioPlayer.enabled = false;
			}
		}
	}

	public void ChangeMuted() {
		if (this.gameObject.GetComponent<Image>().sprite == mutedImage) {
			this.gameObject.GetComponent<Image>().sprite = soundImage;
		} else {
			this.gameObject.GetComponent<Image>().sprite = mutedImage;
		}
		audioPlayer.enabled = !audioPlayer.enabled;
		if (audioPlayer.gameObject.name.Equals("AudioSonidos")) gameManager.changeSoundsActive();
		else if (audioPlayer.gameObject.name.Equals("AudioNivel")) gameManager.changeMusicActive();
	}

}
