using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;

	private void OnEnable()
	{
        lvl1.onClick.AddListener(lvl1Selected);
        lvl2.onClick.AddListener(lvl2Selected);
        lvl3.onClick.AddListener(lvl3Selected);
	}

    public void lvl1Selected() {
        SceneManager.LoadScene(1);
    }

    public void lvl2Selected() {
        Debug.Log("Level 2 Button pressed");
    }

    public void lvl3Selected()
    {
        Debug.Log("Level 3 Button pressed");
    }
}
