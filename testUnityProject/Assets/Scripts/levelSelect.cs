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
    public Button lvl10;
    public Button lvl11;
    public Button lvl12;
    public Button lvl13;
    public Button lvl14;
    public Button lvl15;
    public Button lvl16;
	public Button lvl17;
	public Button lvl18;
	public Button lvl19;
	public Button lvl20;

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
        lvl10.onClick.AddListener(lvl10Selected);
        lvl11.onClick.AddListener(lvl11Selected);
        lvl12.onClick.AddListener(lvl12Selected);
        lvl13.onClick.AddListener(lvl13Selected);
        lvl14.onClick.AddListener(lvl14Selected);
        lvl15.onClick.AddListener(lvl15Selected);
        lvl16.onClick.AddListener(lvl16Selected);
		lvl17.onClick.AddListener(lvl17Selected);
		lvl18.onClick.AddListener(lvl18Selected);
		lvl19.onClick.AddListener(lvl19Selected);
		lvl20.onClick.AddListener(lvl20Selected);
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

    public void lvl10Selected()
    {
        SceneManager.LoadScene(10);
    }

    public void lvl11Selected()
    {
        SceneManager.LoadScene(11);
    }

    public void lvl12Selected()
    {
        SceneManager.LoadScene(12);
    }

    public void lvl13Selected()
    {
        SceneManager.LoadScene(13);
    }

    public void lvl14Selected()
    {
        SceneManager.LoadScene(14);
    }

    public void lvl15Selected()
    {
        SceneManager.LoadScene(15);
    }

    public void lvl16Selected()
    {
        SceneManager.LoadScene(16);
    }

	public void lvl17Selected()
	{
		SceneManager.LoadScene(17);
	}

	public void lvl18Selected()
	{
		SceneManager.LoadScene(18);
	}

	public void lvl19Selected()
	{
		SceneManager.LoadScene(19);
	}

	public void lvl20Selected()
	{
		SceneManager.LoadScene(20);
	}

}
