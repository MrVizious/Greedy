using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour {
	[SerializeField]
	public bool isPaused = false;
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
        SceneManager.LoadScene("MenuPrincipal");
    }

}
