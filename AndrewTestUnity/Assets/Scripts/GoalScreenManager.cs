using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScreenManager : MonoBehaviour {

    public void RestartButtonClicked() {
        PlayerController player = GameObject.Find ("Player").GetComponent <PlayerController>();
        player.ResetPosition();
        player.EnableMovement();
        ScoreAndTimeManager.ResetTimeAndScore();
        ScoreAndTimeManager.UnfreezeTime();
        Destroy (gameObject);
    }
}
