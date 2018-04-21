using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour {
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button lvl4;
    public Button lvl5;
    public Button lvl6;
    public Button lvl7;
    public Button lvl8;
    public Button lvl9;

	private void OnEnable()
	{
        lvl1.onClick.AddListener(lvl1Selected);
        lvl2.onClick.AddListener(lvl2Selected);
        lvl3.onClick.AddListener(lvl3Selected);
        lvl4.onClick.AddListener(lvl4Selected);
        lvl5.onClick.AddListener(lvl5Selected);
        lvl6.onClick.AddListener(lvl6Selected);
        lvl7.onClick.AddListener(lvl7Selected);
        lvl8.onClick.AddListener(lvl8Selected);
        lvl9.onClick.AddListener(lvl9Selected);
	}

    public void lvl1Selected() {
        SceneManager.LoadScene(1);
    }

    public void lvl2Selected() {
        SceneManager.LoadScene(2);
    }

    public void lvl3Selected()
    {
        SceneManager.LoadScene(3);
    }

    public void lvl4Selected()
    {
        SceneManager.LoadScene(4);
    }

    public void lvl5Selected()
    {
        SceneManager.LoadScene(5);
    }

    public void lvl6Selected()
    {
        SceneManager.LoadScene(6);
    }

    public void lvl7Selected()
    {
        SceneManager.LoadScene(7);
    }

    public void lvl8Selected()
    {
        SceneManager.LoadScene(8);
    }

    public void lvl9Selected()
    {
        SceneManager.LoadScene(9);
    }

}
