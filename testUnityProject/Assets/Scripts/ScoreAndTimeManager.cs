using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndTimeManager : MonoBehaviour {
    private static int score;
    private static float time;
    private static bool timeFrozen;

    public Text scoreText;
    public Text timeText;
    public Text millisecondsTimeText;

    void Awake () {
        ResetTimeAndScore ();
        scoreText.text = "Score: " + score;
    }

    public static void ChangeScore(int amount) {
        score += amount;
    }

    public static void FreezeTime() {
        timeFrozen = true;
    }

    public static void UnfreezeTime() {
        timeFrozen = false;
    }

    public static void ResetTimeAndScore() {
        time = 0.0f;
        score = 0;
        timeFrozen = false;

    }


    void Update () {
        scoreText.text = "Score: " + score;

        if (!timeFrozen) {
            time += Time.deltaTime;
            int minutes = (int)time / 60;
            string timerSeconds = (time - 60 * minutes).ToString ("00");
            if (timerSeconds == "60") {
                minutes += 1;
                timerSeconds = "00";
            }
            string timerMinutes = minutes.ToString ("00");

            timeText.text = timerMinutes + ":" + timerSeconds;
            millisecondsTimeText.text = (time - (int)time).ToString(".00");
        }
    }
}
