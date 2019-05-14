using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButtonScript : MonoBehaviour {
	[SerializeField] private Sprite mutedImage;
	[SerializeField] private Sprite soundImage;

	private void Start() {
		this.gameObject.GetComponent<Image>().sprite = soundImage;
	}

	public void ChangeMuted() {
		if (this.gameObject.GetComponent<Image>().sprite == mutedImage) {
			Debug.Log("Sounding");
			AudioListener.pause = false;
			this.gameObject.GetComponent<Image>().sprite = soundImage;
		} else {
			Debug.Log("Muting");
			AudioListener.pause = true;
			this.gameObject.GetComponent<Image>().sprite = mutedImage;
		}
	}

}
