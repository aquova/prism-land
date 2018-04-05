using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titleScreenManager : MonoBehaviour
{
    public Button startButton;
    public Button sceneSelectButton;
    public Button ballButton;
    public Button quitButton;
    public Button backButton;

    GameObject[] titleObjects;
    GameObject[] selectObjects;
    GameObject[] ballObjects;

	private void Start()
	{
        titleObjects = GameObject.FindGameObjectsWithTag("titleScreenItem");
        selectObjects = GameObject.FindGameObjectsWithTag("levelSelectItem");
        ballObjects = GameObject.FindGameObjectsWithTag("ballSelect");
        hideLevels();
	} 

    public void hideLevels() {
        foreach(GameObject g in selectObjects) {
            g.SetActive(false);
        }
        foreach(GameObject h in titleObjects) {
            h.SetActive(true);
        }
        foreach (GameObject i in ballObjects)
        {
            i.SetActive(false);
        }
    }

    public void showLevels() {
        foreach (GameObject g in selectObjects)
        {
            g.SetActive(true);
        }
        foreach (GameObject h in titleObjects)
        {
            h.SetActive(false);
        }
        foreach (GameObject i in ballObjects)
        {
            i.SetActive(false);
        }
    }

    public void showBalls() {
        foreach (GameObject g in selectObjects)
        {
            g.SetActive(false);
        }
        foreach (GameObject h in titleObjects)
        {
            h.SetActive(false);
        }
        foreach (GameObject i in ballObjects) {
            i.SetActive(true);
        }
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(startPressed);
        sceneSelectButton.onClick.AddListener(sceneSelectPressed);
        ballButton.onClick.AddListener(ballPressed);
        quitButton.onClick.AddListener(quitPressed);
        backButton.onClick.AddListener(backPressed);
    }

    public void startPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void quitPressed()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void sceneSelectPressed() {
        showLevels();
    }

    public void ballPressed() {
        showBalls();
    }

    public void backPressed() {
        hideLevels();
    }
}
