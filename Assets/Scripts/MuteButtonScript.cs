using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {
	[SerializeField] private Sprite mutedImage;
	[SerializeField] private Sprite soundImage;
	[SerializeField] private AudioSource audioPlayer;

	private void Start() {
		this.gameObject.GetComponent<Image>().sprite = soundImage;
	}

	public void ChangeMuted() {
		if (this.gameObject.GetComponent<Image>().sprite == mutedImage) {
			Debug.Log("Sounding");
			audioPlayer.enabled = true;
			this.gameObject.GetComponent<Image>().sprite = soundImage;
		} else {
			Debug.Log("Muting");
			audioPlayer.enabled = false;
			this.gameObject.GetComponent<Image>().sprite = mutedImage;
		}
	}

}
