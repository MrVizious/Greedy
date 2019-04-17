using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	private bool isPaused = false;

	public bool IsGamePaused() {
		return this.isPaused;
	}

	[SerializeField]
	private GameObject PauseMenu;
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
		PauseMenu.SetActive(true);
		isPaused = true;

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