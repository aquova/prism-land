using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public GoalScreenManager GoalScreen;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent <finalPlayerScript> () != null) {
            //ScoreAndTimeManager.FreezeTime ();
            //PlayerController p = other.gameObject.GetComponent <PlayerController> ();
            //p.GetComponent<Rigidbody>().AddForce(Vector3.up * 1000f);
            //p.DisableMovement();
            Time.timeScale = 0;
            Instantiate (GoalScreen);
        }
    }
}
