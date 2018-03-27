using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmillRotate : MonoBehaviour {
    public float rotateSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * rotateSpeed);
	}
}
