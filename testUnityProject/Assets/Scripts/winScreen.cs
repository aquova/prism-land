using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winScreen : MonoBehaviour {
    public Button title;

	private void OnEnable()
	{
        title.onClick.AddListener(buttonPressed);
	}

    public void buttonPressed() {
        SceneManager.LoadScene(0);
    }
}
