using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScreenManager : MonoBehaviour {

    public void RestartButtonClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //PlayerController player = GameObject.Find ("Player").GetComponent <PlayerController>();
        //player.ResetPosition();
        //player.EnableMovement();
        //ScoreAndTimeManager.ResetTimeAndScore();
        //ScoreAndTimeManager.UnfreezeTime();
        //Destroy (gameObject);
    }
}
