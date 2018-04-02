using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Pickup : MonoBehaviour {

    public int amount;

    void FixedUpdate() {
        gameObject.transform.Rotate (0, 0, 3);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent <PlayerController> () != null) {
            //PlayerController p = other.gameObject.GetComponent <PlayerController> ();
            Destroy (gameObject);
            ScoreAndTimeManager.ChangeScore (amount);
        }
    }
}
