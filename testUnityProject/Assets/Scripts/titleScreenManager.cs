using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class titleScreenManager : MonoBehaviour
{
    public Button startButton;
    public Button sceneSelectButton;
    public Button instructionsButton;
    public Button quitButton;
    public Button backButton;

    GameObject[] titleObjects;
    GameObject[] selectObjects;

	private void Start()
	{
        titleObjects = GameObject.FindGameObjectsWithTag("titleScreenItem");
        selectObjects = GameObject.FindGameObjectsWithTag("levelSelectItem");
        hideLevels();
	} 

    public void hideLevels() {
        foreach(GameObject g in selectObjects) {
            g.SetActive(false);
        }
        foreach(GameObject h in titleObjects) {
            h.SetActive(true);
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
    }

    private void OnEnable()
    {
        startButton.onClick.AddListener(startPressed);
        sceneSelectButton.onClick.AddListener(sceneSelectPressed);
        instructionsButton.onClick.AddListener(instructionsPressed);
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

    public void instructionsPressed() {
        Debug.Log("Instructions Pressed");
    }

    public void backPressed() {
        hideLevels();
    }
}
