using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public GoalScreenManager GoalScreen;
	GameObject ui;

	void Start() {
		ui = GameObject.FindGameObjectWithTag ("pauseMenu");
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent <finalPlayerScript> () != null) {
			ui.GetComponent<pauseScreenManager> ().setScore ();

            //ScoreAndTimeManager.FreezeTime ();
            //PlayerController p = other.gameObject.GetComponent <PlayerController> ();
            //p.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f);
            //p.DisableMovement();
            Time.timeScale = 0;
            Instantiate (GoalScreen);

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;


        }

    }
}
