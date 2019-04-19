using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour {
	[SerializeField]
	private bool isPaused = false;
	private GameObject PauseMenu;

	private void Start() {
		PauseMenu = GetComponentInChildren<Canvas>().gameObject;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (isPaused) {
				ResumeGame();
			} else {
				PauseGame();
			}
		}
	}
	public bool IsGamePaused() {
		return this.isPaused;
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