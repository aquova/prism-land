using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Back_From_Point : MonoBehaviour {

    public float magnitude;

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            GameObject p = other.gameObject;
            ContactPoint point = other.contacts[0];
            
            Vector3 direction = p.transform.position - point.point;
            p.gameObject.GetComponent <Rigidbody> ().AddForce (direction * magnitude);
        }
    }
}
