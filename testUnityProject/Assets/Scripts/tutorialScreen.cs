using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class tutorialScreen : MonoBehaviour {

	public Text introText;
	bool gameIsPaused = false;

	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "beginnerControlsScene") {
			introText.text = "Use the arrow keys or \"w,a,s,d\" keys to move.  Touch the yellow dot with the purple squares to go to the next level.";
		} 
		else if (SceneManager.GetActiveScene ().name == "beginnerControlsScene2") {
			introText.text = "Use the mouse to look around and find your path.";
		}
		else if (SceneManager.GetActiveScene ().name == "beginnerControlsScene3") {
			introText.text = "You can switch your camera to automatic or change the mouse sensitivity in the pause menu. Try pausing the game by pressing escape.";
		}
		else if (SceneManager.GetActiveScene ().name == "TeachToJumpScene") {
			introText.text = "Press \"Spacebar\" to Jump.";
		}
		else {
			introText.text = "";
		}
	}
	void Update() {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused && SceneManager.GetActiveScene ().name == "beginnerControlsScene3") {
				introText.text = "Your high score will be displayed in the top right corner.  You can exit to menu to go back and try to beat your time!";
				gameIsPaused = false;
			} 
			else {
				introText.text = "";
				gameIsPaused = true;
			}
		}
	}

}
