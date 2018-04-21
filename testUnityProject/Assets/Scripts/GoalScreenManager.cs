using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScreenManager : MonoBehaviour {

    public void RestartButtonClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void TitleButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void NextButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
