using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScreenManager : MonoBehaviour {
    public Button continueButton;
    public Button resetButton;
    public Button titleButton;
    public Button quitButton;
    GameObject[] pauseObjects;

	private void OnEnable()
    {
        continueButton.onClick.AddListener(continuePressed);
        resetButton.onClick.AddListener(resetPressed);
        titleButton.onClick.AddListener(titlePressed);
        quitButton.onClick.AddListener(quitPressed);

        pauseObjects = GameObject.FindGameObjectsWithTag("pausedItem");
    }

    public void quitPressed()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit ();
        #endif
    }

    public void resetPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void titlePressed() {
        SceneManager.LoadScene(0);
    }

    public void continuePressed() {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
        Time.timeScale = 1;
    }
}
