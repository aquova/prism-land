using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class pauseScreenManager : MonoBehaviour {

	//stuff for highscoring and timing
	public Text scoreText;
	public Text timeText;
	public Text levelText;

	private static string score;
	private static float time;
	private static bool timeFrozen;


	public static bool GameIsPaused = false;

	//all the panels here
	public GameObject pauseMenu;
	public GameObject controlsMenu;
	public GameObject cameraMenu;
	public GameObject instructionsMenu;

	//camera gameobjects
	public Camera cameraMain;
	public Camera autoCameraMain;
	public GameObject autoCameraEmpty;

	//player object
	public GameObject playerMain;

	//camera toggle options
	public Toggle mouseToggle;//public GameObject mouseCameraToggle;
	public Toggle autoToggle;//public GameObject autoCameraToggle;

	//sliders
	public Slider xSlider;
	public Slider ySlider;
	public Slider autoSlider;


	void Start() {
		//highscore stuff
		ResetTimeAndScore ();

		setHighScore ();
		//regular stuff
		Resume ();
		autoCameraMain.enabled = false;
		autoCameraEmpty.SetActive (false);
		cameraMain.enabled = true;

		if (PlayerPrefs.HasKey("currentMouseX")) {
			xSlider.value = PlayerPrefs.GetFloat("currentMouseX");
		}
		if (PlayerPrefs.HasKey("currentMouseY")) {
			ySlider.value = PlayerPrefs.GetFloat("currentMouseY");
		}
		if (PlayerPrefs.HasKey("autoCam")) {
			autoSlider.value = PlayerPrefs.GetFloat("autoCam");
		}
		if (PlayerPrefs.HasKey ("cam")) {
			if (PlayerPrefs.GetString ("cam") == "auto") {
				autoCameraChecked (true);
			} else {
				MouseCameraChecked (true);
			}
		}
		string name = SceneManager.GetActiveScene ().name;
		if (name == "beginnerControlsScene" || name == "beginnerControlsScene2" || name == "beginnerControlsScene3" || name == "TeachToJumpScene") {
			levelText.text = "";
		} else {
			int currLevel = SceneManager.GetActiveScene ().buildIndex;
			// If less than 6, say "Tutorial + currLevel"
			// If 6 or higher, say "Level + currLevel - 5"
			if (currLevel < 6) {
				levelText.text = "Tutorial " + currLevel;
			} else {
				levelText.text = "Level " + (currLevel-5);
			}
		}
	}

	public void setHighScore () {
		Debug.Log ("GOT TO SET HIGH SCORE");
		score = "0:00";
		if (PlayerPrefs.HasKey("highScore" + SceneManager.GetActiveScene().name)) {
			score = PlayerPrefs.GetString("highScore" + SceneManager.GetActiveScene().name);
		}
		scoreText.text = "HIGH SCORE: " + score;
	}

	public static void FreezeTime() {
		timeFrozen = true;
	}

	public static void UnfreezeTime() {
		timeFrozen = false;
	}

	public static void ResetTimeAndScore() {
		time = 0.0f;
		timeFrozen = false;
	}

	public void setScore () {
		Debug.Log ("MADE IT TO SET SCORE");
		int minutes = (int)time / 60;
		string timerSeconds = (time - 60 * minutes).ToString ("00");
		if (timerSeconds == "60") {
			minutes += 1;
			timerSeconds = "00";
		}
		string timerMinutes = minutes.ToString ("00");
		if (PlayerPrefs.HasKey ("highScoreTime" + SceneManager.GetActiveScene ().name)) {
			if (PlayerPrefs.GetFloat ("highScoreTime" + SceneManager.GetActiveScene ().name) > time || PlayerPrefs.GetFloat ("highScoreTime" + SceneManager.GetActiveScene ().name) == 0) {
				PlayerPrefs.SetString ("highScore" + SceneManager.GetActiveScene ().name, timerMinutes + ":" + timerSeconds);
				PlayerPrefs.SetFloat ("highScoreTime" + SceneManager.GetActiveScene ().name, time);

				setHighScore ();
			}
		} else {
			PlayerPrefs.SetString ("highScore" + SceneManager.GetActiveScene ().name, timerMinutes + ":" + timerSeconds);
			PlayerPrefs.SetFloat ("highScoreTime" + SceneManager.GetActiveScene ().name, time);

			setHighScore ();
		}

	}

	void FixedUpdate () {
		if (!timeFrozen) {
			time += Time.deltaTime;
			int minutes = (int)time / 60;
			string timerSeconds = (time - 60 * minutes).ToString ("00");
			if (timerSeconds == "60") {
				minutes += 1;
				timerSeconds = "00";
			}
			string timerMinutes = minutes.ToString ("00");

			timeText.text = timerMinutes + ":" + timerSeconds;
		}
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
		PlayerPrefs.SetFloat("currentMouseX", value);
	}
	public void Mouse_Y_Slider (float value) {
		cameraMain.GetComponent<CameraController> ().ySpeed = value;
		PlayerPrefs.SetFloat("currentMouseY", value);
	}

	public void turnSpeedSlider (float value) {
		autoCameraEmpty.GetComponent<autoCamScript> ().turnSpeed = value;
		PlayerPrefs.SetFloat("autoCam", value);
	}

	public void Resume () {
		pauseMenu.SetActive (false);
		controlsMenu.SetActive (false);
		cameraMenu.SetActive (false);
		instructionsMenu.SetActive (false);
		Time.timeScale = 1;
		GameIsPaused = false;

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void Pause () {
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;

		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
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
		if (newVal == true) {
			PlayerPrefs.SetString ("cam", "mouse");

			autoToggle.isOn = false;
			mouseToggle.isOn = true;
			autoCameraMain.enabled = false;
			autoCameraEmpty.SetActive (false);
			cameraMain.enabled = true;

			//setting for player script
			playerMain.GetComponent<finalPlayerScript> ().autoCam = false;
		} else {
			if (mouseToggle.isOn == false && autoToggle.isOn == false) {
				autoCameraChecked (true);
			}
		}
	}

	public void autoCameraChecked(bool newVal) {
		if (newVal == true) {
			PlayerPrefs.SetString ("cam", "auto");

			mouseToggle.isOn = false;
			autoToggle.isOn = true;
			cameraMain.enabled = false;
			autoCameraEmpty.SetActive (true);
			autoCameraMain.enabled = true;

			//setting to turn player movement off
			playerMain.GetComponent<finalPlayerScript> ().autoCam = true;
			//setting camera position
			//Vector3 temp = new Vector3(10, 10, -10);
			//autoCameraEmpty.transform.position = playerMain.transform.position - temp;
		} else {
			if (mouseToggle.isOn == false && autoToggle.isOn == false) {
				MouseCameraChecked (true);
			}
		}
	}
}