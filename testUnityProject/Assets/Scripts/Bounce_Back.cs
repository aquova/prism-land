using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Back : MonoBehaviour {

    public float magnitude;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            GameObject p = other.gameObject;
            Vector3 direction = p.transform.position - transform.position;
            p.gameObject.GetComponent <Rigidbody> ().AddForce (direction * magnitude);
        }
    }
}
