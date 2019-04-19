using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	public bool isPaused = false;

	public bool IsGamePaused() {
		return this.isPaused;
	}

	[SerializeField]
	public GameObject PauseMenu;
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isPaused) {
				ResumeGame();
			} else {
				PauseGame();
			}
		}
	}

	public void PauseGame() {
		Time.timeScale = 0f;
        isPaused = true;
        PauseMenu.SetActive(true);
	}
	public void ResumeGame() {
		Time.timeScale = 1f;
		PauseMenu.SetActive(false);
		isPaused = false;
	}

	public void QuitGame() {
		Application.Quit();
	}

}