using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseBall : MonoBehaviour {
    public Button pacman;
    public Button earth;
    public Button jupiter;
    public Button soccer;
    public Button eightBall;
    public Button archery;
    public GameObject ball;
    public Texture earthTexture;
    public Texture archeryTexture;
    public Texture pacmanTexture;
    public Texture eightBallTexture;
    public Texture jupiterTexture;
    public Texture soccerTexture;

    GameObject[] titleObjects;
    GameObject[] ballObjects;
	
    private void Start() {
        titleObjects = GameObject.FindGameObjectsWithTag("titleScreenItem");
        ballObjects = GameObject.FindGameObjectsWithTag("ballSelect");
    }

    private void OnEnable()
    {
        pacman.onClick.AddListener(pacmanPressed);
        earth.onClick.AddListener(earthPressed);
        jupiter.onClick.AddListener(jupiterPressed);
        soccer.onClick.AddListener(soccerPressed);
        eightBall.onClick.AddListener(eightBallPressed);
        archery.onClick.AddListener(archeryPressed);
    }

    public void archeryPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = archeryTexture;
        showMainMenu();
    }

    public void earthPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = earthTexture;
        showMainMenu();
    }

    public void jupiterPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = jupiterTexture;
        showMainMenu();
    }

    public void pacmanPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = pacmanTexture;
        showMainMenu();
    }

    public void soccerPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = soccerTexture;
        showMainMenu();
    }
    public void eightBallPressed()
    {
        ball.GetComponent<Renderer>().sharedMaterial.mainTexture = eightBallTexture;
        showMainMenu();
    }

    public void showMainMenu()
    {
        foreach (GameObject h in titleObjects)
        {
            h.SetActive(true);
        }
        foreach (GameObject i in ballObjects)
        {
            i.SetActive(false);
        }
    }
}
