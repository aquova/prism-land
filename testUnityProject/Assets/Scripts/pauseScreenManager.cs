using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pauseScreenManager : MonoBehaviour {
	public static bool GameIsPaused = false;

	//all the panels here
	public GameObject pauseMenu;
	public GameObject controlsMenu;
	public GameObject cameraMenu;

	//camera gameobjects
	public Camera cameraMain;
	public Camera autoCameraMain;
	public GameObject autoCameraEmpty;

	//player object
	public GameObject playerMain;

	//camera toggle options
	public Toggle mouseToggle;//public GameObject mouseCameraToggle;
	public Toggle autoToggle;//public GameObject autoCameraToggle;

	void Start() {
		Resume ();
		autoCameraMain.enabled = false;
		autoCameraEmpty.SetActive (false);
		cameraMain.enabled = true;

	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GameIsPaused) {
				Resume ();
			} 
			else {
				Pause ();
			}
		}
	}

	public void Mouse_X_Slider (float value) {
		cameraMain.GetComponent<CameraController> ().xSpeed = value;
	}
	public void Mouse_Y_Slider (float value) {
		cameraMain.GetComponent<CameraController> ().ySpeed = value;
	}

	public void Resume () {
		pauseMenu.SetActive (false);
		controlsMenu.SetActive (false);
		cameraMenu.SetActive (false);
		Time.timeScale = 1;
		GameIsPaused = false;
	}

	void Pause () {
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
	}

	public void Menu () {
		SceneManager.LoadScene(0);
	}

	public void quitGame() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

	public void resetPressed() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MouseCameraChecked(bool newVal) {
		Debug.Log ("mouse camera method.  Bool: "+newVal);
		if (newVal == true) {
			autoToggle.isOn = false;
			autoCameraMain.enabled = false;
			autoCameraEmpty.SetActive (false);
			cameraMain.enabled = true;

			//setting for player script
			playerMain.GetComponent<finalPlayerScript> ().autoCam = false;

		}
	}

	public void autoCameraChecked(bool newVal) {
		Debug.Log ("auto camera method.  Bool: "+newVal);
		if (newVal == true) {
			mouseToggle.isOn = false;
			cameraMain.enabled = false;
			autoCameraEmpty.SetActive (true);
			autoCameraMain.enabled = true;

			//setting to turn player movement off
			playerMain.GetComponent<finalPlayerScript> ().autoCam = true;
			//setting camera position
			//Vector3 temp = new Vector3(10, 10, -10);
			//autoCameraEmpty.transform.position = playerMain.transform.position - temp;
		}
	}
}